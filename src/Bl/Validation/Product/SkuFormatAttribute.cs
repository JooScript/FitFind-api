using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ECommerce.Bl.Validation.Product;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class SkuFormatAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null) return true; // Let Required attribute handle null checks

        return Regex.IsMatch(value.ToString(), @"^PROD-[a-zA-Z0-9]+$");
    }

    public override string FormatErrorMessage(string name)
    {
        return $"The {name} field must start with 'PROD-' followed by alphanumeric characters.";
    }

}