using Microsoft.AspNetCore.Identity;

namespace ECommerce.Da.Identity;

public class AppRole : IdentityRole<Guid>
{
    public AppRole() : base() { }

    public AppRole(string roleName) : base(roleName) { }

    public AppRole(string roleName, string rolePermisstions) : base(roleName)
    {
        RolePermisstions = rolePermisstions;
    }


    public string RolePermisstions { get; set; } = "Test";
}