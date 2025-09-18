using ECommerce.Domains.Base;
using System.Text;


namespace ECommerce.Domains.Models;

public partial class TbProduct : BaseTable
{
    public string Sku { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ShortDescription { get; set; }

    public decimal Price { get; set; }

    public decimal? CostPrice { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Height { get; set; }

    public bool? IsDigital { get; set; }

    public int? StockQuantity { get; set; }

    public int? LowStockThreshold { get; set; }

    public virtual ICollection<TbCartItem> TbCartItems { get; set; } = new List<TbCartItem>();

    public virtual ICollection<TbDiscountProductMapping> TbDiscountProductMappings { get; set; } = new List<TbDiscountProductMapping>();

    public virtual ICollection<TbImage> TbImages { get; set; } = new List<TbImage>();

    public virtual ICollection<TbInventoryTransaction> TbInventoryTransactions { get; set; } = new List<TbInventoryTransaction>();

    public virtual ICollection<TbOrderItem> TbOrderItems { get; set; } = new List<TbOrderItem>();

    public virtual ICollection<TbProductCategoryMapping> TbProductCategoryMappings { get; set; } = new List<TbProductCategoryMapping>();

    public virtual ICollection<TbProductSupplier> TbProductSuppliers { get; set; } = new List<TbProductSupplier>();

    public virtual ICollection<TbProductTagMapping> TbProductTagMappings { get; set; } = new List<TbProductTagMapping>();

    public virtual ICollection<TbProductTranslationMapping> TbProductTranslationMappings { get; set; } = new List<TbProductTranslationMapping>();

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();

    public virtual ICollection<TbSeoMetum> TbSeoMeta { get; set; } = new List<TbSeoMetum>();

    public virtual ICollection<TbSubscription> TbSubscriptions { get; set; } = new List<TbSubscription>();

    public virtual ICollection<TbVariation> TbVariations { get; set; } = new List<TbVariation>();

    public virtual ICollection<TbWishlistItem> TbWishlistItems { get; set; } = new List<TbWishlistItem>();

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Product: {Name}");
        sb.AppendLine($"SKU: {Sku}");
        sb.AppendLine($"Price: {Price:C}");
        sb.AppendLine($"Cost Price: {CostPrice?.ToString("C") ?? "N/A"}");
        sb.AppendLine($"Description: {Description ?? "No description"}");
        sb.AppendLine($"Stock Quantity: {StockQuantity?.ToString() ?? "N/A"}");
        sb.AppendLine($"Low Stock Threshold: {LowStockThreshold?.ToString() ?? "N/A"}");
        sb.AppendLine($"Is Digital: {IsDigital?.ToString() ?? "No"}");
        sb.AppendLine($"Weight: {Weight?.ToString() ?? "N/A"}");
        sb.AppendLine($"Dimensions: {Length?.ToString() ?? "N/A"} x {Width?.ToString() ?? "N/A"} x {Height?.ToString() ?? "N/A"}");

        return sb.ToString();
    }

}
