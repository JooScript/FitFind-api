using ECommerce.Bl.Dtos.Base;
using ECommerce.Bl.Validation.Product;
using System.ComponentModel.DataAnnotations;
using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Bl.Dtos.Business;

/// <summary>
/// Represents a product data transfer object.
/// Implements <see cref="IValidatableObject"/> for custom validation rules.
/// </summary>
public class ProductDto : BaseDto<enCurrentState>, IValidatableObject
{
    /// <summary>
    /// Gets or sets the stock keeping unit (SKU) for the product.
    /// Must start with 'PROD-' followed by alphanumeric characters.
    /// </summary>
    /// <example>PROD-12345</example>
    [Required(ErrorMessage = "SKU is required")]
    [StringLength(50, ErrorMessage = "SKU cannot exceed 50 characters")]
    [SkuFormat(ErrorMessage = "SKU must start with 'PROD-' followed by alphanumeric characters")]
    public string Sku { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    /// <example>Premium Wireless Headphones</example>
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the product.
    /// </summary>
    /// <example>Noise-cancelling wireless headphones with 30-hour battery life</example>
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the short description of the product.
    /// </summary>
    /// <example>Premium noise-cancelling headphones</example>
    [StringLength(150, ErrorMessage = "Short description cannot exceed 150 characters")]
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Gets or sets the selling price of the product.
    /// </summary>
    /// <example>199.99</example>
    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1,000,000")]
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the cost price of the product.
    /// </summary>
    /// <example>120.50</example>
    [Range(0, 1000000, ErrorMessage = "Cost price must be between 0 and 1,000,000")]
    public decimal? CostPrice { get; set; }

    /// <summary>
    /// Gets or sets the weight of the product in kilograms.
    /// Required for physical products.
    /// </summary>
    /// <example>0.5</example>
    [Range(0, 1000, ErrorMessage = "Weight must be between 0 and 1000")]
    public decimal? Weight { get; set; }

    /// <summary>
    /// Gets or sets the length of the product in centimeters.
    /// Required for physical products.
    /// </summary>
    /// <example>20.5</example>
    [Range(0, 100, ErrorMessage = "Length must be between 0 and 100")]
    public decimal? Length { get; set; }

    /// <summary>
    /// Gets or sets the width of the product in centimeters.
    /// Required for physical products.
    /// </summary>
    /// <example>15.2</example>
    [Range(0, 100, ErrorMessage = "Width must be between 0 and 100")]
    public decimal? Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the product in centimeters.
    /// Required for physical products.
    /// </summary>
    /// <example>7.8</example>
    [Range(0, 100, ErrorMessage = "Height must be between 0 and 100")]
    public decimal? Height { get; set; }

    /// <summary>
    /// Gets or sets whether the product is digital (no physical shipment required).
    /// </summary>
    /// <example>false</example>
    public bool? IsDigital { get; set; }

    /// <summary>
    /// Gets or sets the current stock quantity.
    /// </summary>
    /// <example>150</example>
    [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
    public int? StockQuantity { get; set; }

    /// <summary>
    /// Gets or sets the low stock threshold for inventory alerts.
    /// Must be less than stock quantity if both are provided.
    /// </summary>
    /// <example>10</example>
    [Range(0, int.MaxValue, ErrorMessage = "Low stock threshold cannot be negative")]
    public int? LowStockThreshold { get; set; }

    /// <summary>
    /// Validates the product data using custom business rules.
    /// </summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection of validation results.</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (LowStockThreshold.HasValue && StockQuantity.HasValue && LowStockThreshold >= StockQuantity)
        {
            yield return new ValidationResult(
                "Low stock threshold must be less than stock quantity",
                new[] { nameof(LowStockThreshold) });
        }

        if (IsDigital == false)
        {
            if (!Weight.HasValue)
                yield return new ValidationResult(
                    "Weight is required for physical products",
                    new[] { nameof(Weight) });

            if (!Length.HasValue)
                yield return new ValidationResult(
                    "Length is required for physical products",
                    new[] { nameof(Length) });

            if (!Width.HasValue)
                yield return new ValidationResult(
                    "Width is required for physical products",
                    new[] { nameof(Width) });

            if (!Height.HasValue)
                yield return new ValidationResult(
                    "Height is required for physical products",
                    new[] { nameof(Height) });
        }
    }
}
