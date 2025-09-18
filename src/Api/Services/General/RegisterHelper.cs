
using Api.Services;
using Api.Services.General;
using ECommerce.Api.Middlewares;
using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Contracts.Events;
using ECommerce.Bl.Events.Publishers;
using ECommerce.Bl.Events.Subscribers;
using ECommerce.Bl.Mapping;
using ECommerce.Bl.Services.Auditing;
using ECommerce.Bl.Services.Auth;
using ECommerce.Bl.Services.Business;
using ECommerce.Da.Context;
using ECommerce.Da.Contracts;
using ECommerce.Da.Identity;
using ECommerce.Da.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ECommerce.Api.Services.General;

public static class RegisterHelper
{
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        #region ILogger

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        #endregion

        builder.Host.UseSerilog();
        builder.Services.AddAuthorization();
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        #region EF

        builder.Services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail = true;
            options.User.RequireUniqueEmail = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.AllowedForNewUsers = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = false;
        }).AddEntityFrameworkStores<ECommerceContext>().AddDefaultTokenProviders();

        #endregion

        #region DI

        #region Middlewares

        builder.Services.AddTransient<ErrorHandlingMiddleware>();

        #endregion

        #region General

        builder.Services.AddScoped(typeof(ITableRepoQry<>), typeof(TableQryRepo<>));
        builder.Services.AddScoped(typeof(ITableRepoCmd<>), typeof(TableCmdRepo<>));
        builder.Services.AddScoped(typeof(IViewRepo<>), typeof(ViewRepo<>));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserServiceQry, UserService>();
        builder.Services.AddScoped<IUserServiceCmd, UserService>();
        builder.Services.AddScoped<IRefreshTokens, RefreshTokenService>();
        builder.Services.AddScoped<IAuditLog, AuditLogService>();


        builder.Services.AddScoped<ICrudPublisher, CrudPublisher>();
        builder.Services.AddScoped<IAuditLogSubscriber, AuditLogSubscriber>();


        #endregion

        #region Bl

        builder.Services.AddScoped<IProduct, ProductService>();
        builder.Services.AddScoped<ISupportTicket, SupportTicketService>();

        #endregion

        #endregion

        return builder;
    }

    public static async Task<WebApplication> UseApplicationStartup(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
        var dbContext = services.GetRequiredService<ECommerceContext>();

        await dbContext.Database.MigrateAsync();
        await ContextConfig.SeedDataAsync(dbContext, userManager, roleManager);



        return app;
    }

}