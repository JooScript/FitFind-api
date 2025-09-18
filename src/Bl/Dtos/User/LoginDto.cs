using ECommerce.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Bl.Dtos.User;

public class LoginDto
{
    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "EmailRequired")]
    [EmailAddress(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "InvalidEmail")]
    public string Email { get; set; }

    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "PasswordRequired")]
    [MinLength(6, ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "PasswordMinLength")]
    public string Password { get; set; }
}
