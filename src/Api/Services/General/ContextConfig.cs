using ECommerce.Da.Context;
using ECommerce.Da.Identity;
using Microsoft.AspNetCore.Identity;

namespace Api.Services.General;

public class ContextConfig
{
    private static readonly string seedAdminEmail = "admin@gmail.com";

    public static async Task SeedDataAsync(ECommerceContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) => await SeedUserAsync(userManager, roleManager);

    private static async Task SeedUserAsync(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new AppRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new AppRole("User"));
        }

        var adminUser = await userManager.FindByEmailAsync(seedAdminEmail);

        if (adminUser == null)
        {
            adminUser = new AppUser
            {
                UserName = seedAdminEmail,
                Email = seedAdminEmail,
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                Phone = "65656566",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@123456");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                throw new Exception(result.Errors.ToString());
            }

        }
    }

}
