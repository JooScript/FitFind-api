using ECommerce.Api.Constants;
using ECommerce.Api.Extentions;
using ECommerce.Api.Middlewares;
using ECommerce.Api.Services.General;
using ECommerce.Bl.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace ECommerce.Api;

public class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args).AddApplicationServices();

        builder.Services.AddApplication();

        builder.Services.AddRateLimiters();

        builder.Services.AddMemoryCache();

        #region Cors

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("https://localhost:7279").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });
        });

        #endregion

        #region JsonApiFormat

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        #endregion

        builder.Services.AddEndpointsApiExplorer();

        #region Swagger

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "E-Commerce API",
                Description = "API to access E-Commerce items and related categories",
                TermsOfService = new Uri("https://JooScript.com"),
                Contact = new OpenApiContact
                {
                    Email = "contactyousefrefat@gmail.com",
                    Name = "Yousef R Awad",
                    Url = new Uri("https://JooScript.com")
                },
                License = new OpenApiLicense
                {
                    Name = "Joo Script Licence",
                    Url = new Uri("https://JooScript.com")
                }
            });

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

            options.UseAllOfToExtendReferenceSchemas();
        });

        #endregion

        #region JWT

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = "/login";
               options.AccessDeniedPath = "/access-denied";
           });

        var jwtSecretKey = builder.Configuration.GetValue<string>("Jwt:Key");
        var key = Encoding.ASCII.GetBytes(jwtSecretKey);

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {

                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,  // Typically set to true in production
                ValidateIssuerSigningKey = true
            };
        });

        #endregion

        var app = builder.Build();
        await app.UseApplicationStartup();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowFrontend");

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseMiddleware<EventsSubscriptionMiddleware>();
        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseRateLimiter();

        app.MapControllers();

        app.Run();
    }
}