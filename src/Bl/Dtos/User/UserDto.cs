using ECommerce.Bl.Dtos.Base;
using ECommerce.Core.Resources;
using System.ComponentModel.DataAnnotations;
using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Bl.Dtos.User;

public class UserDto : BaseDto<enCurrentState>
{
    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "EmailRequired")]
    [EmailAddress(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "InvalidEmail")]
    public string Email { get; set; }

    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "UserNameRequired")]
    public string UserName { get; set; }

    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "PasswordRequired")]
    [MinLength(8, ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "PasswordMinLength")]
    public string Password { get; set; }

    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "ConfirmPasswordRequired")]
    [Compare("Password", ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "PasswordMismatch")]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "FirstNameRequired")]
    [StringLength(50, ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "FirstNameMaxLength")]
    public string FirstName { get; set; }

    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "LastNameRequired")]
    [StringLength(50, ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "LastNameMaxLength")]
    public string LastName { get; set; }

    [Required(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "PhoneRequired")]
    [Phone(ErrorMessageResourceType = typeof(ResMessages), ErrorMessageResourceName = "InvalidPhone")]
    public string? Phone { get; set; }

    public List<string>? Roles { get; set; }

}

