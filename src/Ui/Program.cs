using Api.Services.General;
using ECommerce.Api.Services.General;
using ECommerce.Ui.Services.General;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Http.Headers;

namespace ECommerce.Ui;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args).AddApplicationServices();

        builder.Services.AddControllersWithViews();

        builder.Services.AddHttpClient("ApiClient", client =>
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.AccessDeniedPath = "/access-denied";
            options.SlidingExpiration = true;
            options.Cookie.IsEssential = true;
            options.ExpireTimeSpan = TimeSpan.FromDays(7);
        });

        builder.Services.AddScoped<GenericApiClient>();


        WebApplication app = builder.Build();
        await app.UseApplicationStartup();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        #region Routes

        app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        #endregion


        app.Run();
    }
}
