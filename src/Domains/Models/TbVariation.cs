using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbVariation :BaseTable
{
    public Guid? ProductId { get; set; }

    public string Sku { get; set; } = null!;

    public string VariationName { get; set; } = null!;

    public decimal? PriceAdjustment { get; set; }

    public int? StockQuantity { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual ICollection<TbCartItem> TbCartItems { get; set; } = new List<TbCartItem>();

    public virtual ICollection<TbInventoryTransaction> TbInventoryTransactions { get; set; } = new List<TbInventoryTransaction>();

    public virtual ICollection<TbOrderItem> TbOrderItems { get; set; } = new List<TbOrderItem>();

    public virtual ICollection<TbVariationAttributeMapping> TbVariationAttributeMappings { get; set; } = new List<TbVariationAttributeMapping>();
}
