using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models;

public class ApplicationRole : IdentityRole
{
    public string RolePermisstions { get; set; }
}
