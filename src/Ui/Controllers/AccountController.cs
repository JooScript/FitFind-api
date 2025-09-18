using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Dtos.User;
using ECommerce.Ui.Models;
using ECommerce.Ui.Services.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Ui.Controllers;

public class AccountController : Controller
{
    IUserServiceQry _userServiceQuery;
    IUserServiceCmd _userServiceCommand;

    private readonly GenericApiClient _apiClient;

    public AccountController(IUserServiceQry userServiceQuery, IUserServiceCmd userServiceCommand, GenericApiClient apiClient)
    {
        _userServiceQuery = userServiceQuery;
        _userServiceCommand = userServiceCommand;
        _apiClient = apiClient;
    }

    public IActionResult Login()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _userServiceCommand.LogoutAsync();
        return View("Login");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDto user)
    {
        if (!ModelState.IsValid)
            return View(user);

        var result = await _userServiceCommand.LoginAsync(user);
        if (result.Success)
        {
            // Call the login API using the generic client
            LoginApiModel apiResult = await _apiClient.PostAsync<LoginApiModel>("api/auth/login", user);

            if (apiResult == null)
            {
                ModelState.AddModelError(string.Empty, "API error: Unable to process login.");
                return View(user);
            }

            var accessToken = apiResult?.AccessToken.ToString();

            if (string.IsNullOrEmpty(accessToken))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(user);
            }
            // Store the access token in the cookie (for subsequent requests)
            Response.Cookies.Append("AccessToken", accessToken, new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                Expires = DateTime.UtcNow.AddMinutes(15)  // Adjust token expiry based on your needs
            });

            Response.Cookies.Append("RefreshToken", apiResult?.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(7)  // Adjust token expiry based on your needs
            });

            var dbUser = await _userServiceQuery.GetUserByEmailAsync(user.Email);

            if (dbUser.Roles.Any(r => r.Equals("admin", StringComparison.OrdinalIgnoreCase)))
                return RedirectToRoute(new { area = "admin", controller = "Home", action = "Index" });
            else
                return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        else
            return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserDto user)
    {
        if (!ModelState.IsValid)
            return View(user);

        var result = await _userServiceCommand.RegisterAsync(user);
        if (result.Success)
        {
            return RedirectToRoute(new { controller = "Account", action = "Login" });
        }
        else
            return View();
    }
}
