using ECommerce.Api.Models;
using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Api.Controllers.Auth;

/// <summary>
/// Provides authentication and authorization endpoints including
/// user registration, login, logout, token refresh, email confirmation,
/// password reset, and two-factor authentication.
/// </summary>
/// <remarks>
/// This controller manages authentication flows using JWT access tokens
/// and refresh tokens stored in cookies.  
/// Access tokens are short-lived, while refresh tokens are long-lived
/// and are persisted server-side to allow rotation and invalidation.
/// </remarks>
[Route("api/v1/auth")]
[ApiController]
[Authorize]
public class AuthController(ITokenService tokenService, IUserQryService userServiceQuery, IUserServiceCmd userServiceCommand, IRefreshTokens refreshTokenService) : ControllerBase
{
    private readonly string RefreshTokenCookieName = "RefreshToken";
    private readonly string AccessTokenCookieName = "AccessToken";

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="request">User registration data.</param>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 with success message if registration succeeds.  
    /// - 400 with validation or business errors if registration fails.  
    /// </returns>
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ApiResponse<string>.FailResponse(
                "Validation failed",
                ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
        }

        UserResultDto result = await userServiceCommand.RegisterAsync(request);

        if (result.Success)
        {
            var response = ApiResponse<string>.SuccessResponse("User registered successfully");
            return Ok(response);
        }

        var errorResponse = ApiResponse<string>.FailResponse("Registration failed", result.Errors);
        return BadRequest(errorResponse);
    }

    /// <summary>
    /// Authenticates a user and issues access and refresh tokens.
    /// </summary>
    /// <param name="request">Login credentials (email, password).</param>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 with access and refresh tokens if login succeeds.  
    /// - 200 with <c>Requires2FA=true</c> if two-factor authentication is required.  
    /// - 401 with error messages if login fails.  
    /// </returns>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        if (!ModelState.IsValid)
        {
            var validationErrors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return BadRequest(ApiResponse<object>.FailResponse("Validation failed", validationErrors));
        }

        var userResult = await userServiceCommand.LoginAsync(request);

        if (!userResult.Success)
            return Unauthorized(ApiResponse<object>.FailResponse("Login failed", userResult.Errors));

        if (userResult.Requires2FA)
        {
            return Ok(ApiResponse<object>.SuccessResponse(new { Requires2FA = true }, "2FA required"));
        }

        var userData = await userServiceQuery.GetClaims(request.Email);
        var accessToken = tokenService.GenerateAccessToken(userData.claims);
        var refreshToken = tokenService.GenerateRefreshToken();

        var storedToken = new RefreshTokenDto
        {
            Token = refreshToken,
            UserId = userData.user.Id,
            Expires = DateTime.UtcNow.AddDays(7),
            CurrentState = enCurrentState.Active
        };

        refreshTokenService.Refresh(storedToken);

        Response.Cookies.Append(RefreshTokenCookieName, refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = storedToken.Expires
        });

        var loginResponse = new
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return Ok(ApiResponse<object>.SuccessResponse(loginResponse, "Login successful"));
    }

    /// <summary>
    /// Completes login using two-factor authentication (2FA).
    /// </summary>
    /// <param name="dto">Two-factor authentication data (email and verification code).</param>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 with access and refresh tokens if verification succeeds.  
    /// - 401 with errors if verification fails.  
    /// </returns>
    [AllowAnonymous]
    [HttpPost("LoginWith2FA")]
    public async Task<IActionResult> LoginWith2FA([FromBody] TwoFactorDto dto)
    {
        var result = await userServiceCommand.LoginWith2FAAsync(dto);

        if (!result.Success)
        {
            return Unauthorized(ApiResponse<object>.FailResponse("Two-factor authentication failed.", result.Errors));
        }

        var user = await userServiceQuery.GetUserByEmailAsync(dto.Email);
        var claims = await userServiceQuery.GetClaims(user.Id);
        var accessToken = tokenService.GenerateAccessToken(claims.claims);
        var refreshToken = tokenService.GenerateRefreshToken();

        var storedToken = new RefreshTokenDto
        {
            Token = refreshToken,
            UserId = user.Id,
            Expires = DateTime.UtcNow.AddDays(7),
            CurrentState = enCurrentState.Active
        };

        await refreshTokenService.Refresh(storedToken);

        Response.Cookies.Append(RefreshTokenCookieName, refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = storedToken.Expires
        });

        var tokenResponse = new
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return Ok(ApiResponse<object>.SuccessResponse(tokenResponse, "Login with 2FA successful."));
    }

    /// <summary>
    /// Confirms a user's email address using a token sent via email.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="token">The email confirmation token.</param>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 if email confirmation succeeds.  
    /// - 400 if confirmation fails.  
    /// </returns>
    [AllowAnonymous]
    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] Guid userId, [FromQuery] string token)
    {
        var result = await userServiceCommand.ConfirmEmailAsync(userId, token);

        if (!result)
        {
            return BadRequest(ApiResponse<object>.FailResponse("Email confirmation failed."));
        }

        return Ok(ApiResponse<object>.SuccessResponse(null, "Email confirmed successfully."));
    }

    /// <summary>
    /// Sends a password reset link to the user's email.
    /// </summary>
    /// <param name="dto">Data containing the user's email address.</param>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 if reset link is sent successfully.  
    /// - 400 if operation fails.  
    /// </returns>
    [AllowAnonymous]
    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        var result = await userServiceCommand.SendPasswordResetTokenAsync(dto.Email);

        if (!result)
        {
            return BadRequest(ApiResponse<object>.FailResponse("Failed to send password reset link."));
        }

        return Ok(ApiResponse<object>.SuccessResponse(null, "Password reset email sent successfully."));
    }

    /// <summary>
    /// Resets a user's password using a valid reset token.
    /// </summary>
    /// <param name="dto">Password reset data including email, token, and new password.</param>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 if password is reset successfully.  
    /// - 400 if reset fails.  
    /// </returns>
    [AllowAnonymous]
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
    {
        var result = await userServiceCommand.ResetPasswordAsync(dto);

        if (!result)
        {
            return BadRequest(ApiResponse<object>.FailResponse("Password reset failed."));
        }

        return Ok(ApiResponse<object>.SuccessResponse(null, "Password has been reset successfully."));
    }

    /// <summary>
    /// Logs the current user out and clears authentication cookies.
    /// </summary>
    /// <returns>200 with success message.</returns>
    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await userServiceCommand.LogoutAsync();

        Response.Cookies.Delete(RefreshTokenCookieName);
        Response.Cookies.Delete(AccessTokenCookieName);

        return Ok(ApiResponse<object>.SuccessResponse(null, "Logged out successfully."));
    }

    /// <summary>
    /// Refreshes the access token using the refresh token stored in cookies.
    /// </summary>
    /// <remarks>
    /// This endpoint is typically used by clients when the access token
    /// expires. The refresh token must be valid, active, and not expired.  
    /// A new short-lived access token is returned and set in cookies.
    /// </remarks>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 with new access token if refresh token is valid.  
    /// - 401 if refresh token is invalid or expired.  
    /// </returns>
    [HttpPost("RefreshAccessToken")]
    public async Task<IActionResult> RefreshAccessToken()
    {
        if (!Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken))
        {
            return Unauthorized(ApiResponse<object>.FailResponse("No refresh token found."));
        }

        var storedToken = await refreshTokenService.GetByToken(refreshToken);

        if (storedToken == null ||
            storedToken.CurrentState == enCurrentState.InActive ||
            storedToken.Expires < DateTime.UtcNow)
        {
            return Unauthorized(ApiResponse<object>.FailResponse("Invalid or expired refresh token."));
        }

        var claims = await userServiceQuery.GetClaims(storedToken.UserId);
        var newAccessToken = tokenService.GenerateAccessToken(claims.claims);

        Response.Cookies.Append(AccessTokenCookieName, newAccessToken, new CookieOptions
        {
            HttpOnly = false, // Consider true if JS doesn’t need direct access
            Secure = true,
            Expires = DateTime.UtcNow.AddMinutes(15)
        });

        return Ok(ApiResponse<string>.SuccessResponse(newAccessToken, "Access token refreshed successfully."));
    }

    /// <summary>
    /// Issues a new refresh token, replacing the old one.
    /// </summary>
    /// <remarks>
    /// Refresh token rotation helps reduce the impact of token theft.
    /// A new refresh token is generated and stored, while the old one
    /// becomes invalid.
    /// </remarks>
    /// <returns>
    /// <see cref="IActionResult"/>  
    /// - 200 with new refresh token if the old one is valid.  
    /// - 401 if old refresh token is invalid or expired.  
    /// </returns>
    [HttpPost("Refresh")]
    public async Task<IActionResult> Refresh()
    {
        if (!Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken))
        {
            return Unauthorized(ApiResponse<object>.FailResponse("No refresh token found."));
        }

        var storedToken = await refreshTokenService.GetByToken(refreshToken);

        if (storedToken == null ||
            storedToken.CurrentState == enCurrentState.InActive ||
            storedToken.Expires < DateTime.UtcNow)
        {
            return Unauthorized(ApiResponse<object>.FailResponse("Invalid or expired refresh token."));
        }

        var newRefreshToken = tokenService.GenerateRefreshToken();

        var newRefreshDto = new RefreshTokenDto
        {
            Token = newRefreshToken,
            UserId = storedToken.UserId,
            Expires = DateTime.UtcNow.AddDays(7),
            CurrentState = enCurrentState.Active
        };

        refreshTokenService.Refresh(newRefreshDto);

        Response.Cookies.Append(RefreshTokenCookieName, newRefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            Expires = newRefreshDto.Expires
        });

        return Ok(ApiResponse<string>.SuccessResponse(newRefreshToken, "Refresh token issued successfully."));
    }
}