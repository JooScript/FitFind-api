using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Dtos.User;
using ECommerce.Da.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services;

public class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IConfiguration config, ILogger<UserService> logger) : IUserServiceQry, IUserServiceCmd
{
    private const string DefaultRole = "User";

    public async Task<UserResultDto> RegisterAsync(UserDto dto)
    {
        if (dto.Password != dto.ConfirmPassword)
            return Fail("Passwords do not match.");

        AppUser user = new AppUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone
        };

        var result = await userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            return Fail(result.Errors.Select(e => e.Description).ToList());
        }

        var roles = dto.Roles.Any() ? new List<string> { DefaultRole } : dto.Roles;

        foreach (var role in roles)
        {
            var roleResult = await userManager.AddToRoleAsync(user, role);
            if (!roleResult.Succeeded)
            {
                return Fail(roleResult.Errors.Select(e => e.Description).ToList());
            }
        }

        return new UserResultDto { Success = true };
    }

    public async Task<UserResultDto> LoginAsync(LoginDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);

        if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
            return Fail("Invalid login.");

        if (!await userManager.IsEmailConfirmedAsync(user))
            return Fail("Email not confirmed.");

        if (await userManager.GetTwoFactorEnabledAsync(user))
            return new UserResultDto { Success = true, Requires2FA = true };

        return new UserResultDto { Success = true, Token = await GenerateJwtToken(user) };
    }

    public async Task<UserResultDto> LoginWith2FAAsync(TwoFactorDto dto)
    {
        var user = await signInManager.GetTwoFactorAuthenticationUserAsync();

        if (user == null)
            return Fail("No 2FA user found.");

        var result = await signInManager.TwoFactorAuthenticatorSignInAsync(dto.TwoFactorCode.Replace(" ", "").Replace("-", ""), dto.RememberMe, dto.RememberMachine);

        if (!result.Succeeded)
            return Fail("Invalid 2FA code.");

        return new UserResultDto { Success = true, Token = await GenerateJwtToken(user) };
    }

    public async Task LogoutAsync() => await signInManager.SignOutAsync();

    public async Task<UserDto?> GetUserByIdAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        return user == null ? null : await ToUserDto(user);
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        return user == null ? null : await ToUserDto(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = userManager.Users.ToList();
        var results = new List<UserDto>();

        foreach (var user in users)
            results.Add(await ToUserDto(user));

        return results;
    }

    //public Guid GetLoggedInUserId() => Guid.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out var guid) ? guid : Guid.Empty;

    public Guid GetLoggedInUserId() => Guid.TryParse("f8034b71-ed00-4a09-380b-08dde9453687", out Guid guid) ? guid : Guid.Empty;

    public async Task<bool> ConfirmEmailAsync(Guid userId, string token)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());

        if (user == null) return false;

        var result = await userManager.ConfirmEmailAsync(user, Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token)));
        return result.Succeeded;
    }

    public async Task<bool> SendPasswordResetTokenAsync(string email)
    {
        AppUser? user = await userManager.FindByEmailAsync(email);
        return user != null && await userManager.IsEmailConfirmedAsync(user);
    }

    public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
    {
        AppUser? user = await userManager.FindByEmailAsync(dto.Email);

        if (user == null) return true;

        var result = await userManager.ResetPasswordAsync(user, Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(dto.Token)), dto.NewPassword);
        return result.Succeeded;
    }

    #region Helpers

    private async Task<string> GenerateJwtToken(AppUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

        var roles = await userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddDays(7);

        var token = new JwtSecurityToken(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<UserDto> ToUserDto(AppUser user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Phone = user.Phone,
            Roles = (List<string>)await userManager.GetRolesAsync(user)
        };
    }

    private static UserResultDto Fail(string error) => new UserResultDto { Success = false, Errors = new List<string> { error } };

    private static UserResultDto Fail(List<string> errors) => new UserResultDto { Success = false, Errors = errors };

    private async Task<(Claim[] claims, UserDto user)> BuildUserClaims(UserDto user)
    {
        var roles = await GetUserRolesAsync(user.Id);

        var claims = new List<Claim>
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        if (!roles.Contains("User"))
        {
            claims.Add(new Claim(ClaimTypes.Role, "User"));
        }

        return (claims.ToArray(), user);
    }

    #endregion

    public async Task<IEnumerable<string>> GetUserRolesAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            throw new InvalidOperationException($"User with ID '{userId}' was not found.");
        }

        return await userManager.GetRolesAsync(user);
    }

    public async Task<(Claim[] claims, UserDto user)> GetClaims(string email)
    {
        var user = await GetUserByEmailAsync(email);
        return await BuildUserClaims(user);
    }

    public async Task<(Claim[] claims, UserDto user)> GetClaims(Guid userId)
    {
        var user = await GetUserByIdAsync(userId);
        return await BuildUserClaims(user);
    }

}
