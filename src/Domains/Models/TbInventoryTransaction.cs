using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbInventoryTransaction :BaseTable
{
    public Guid? ProductId { get; set; }

    public Guid? VariationId { get; set; }

    public int QuantityChange { get; set; }

    public string TransactionType { get; set; } = null!;

    public Guid? ReferenceId { get; set; }

    public string? ReferenceType { get; set; }

    public string? Notes { get; set; }

    public DateTimeOffset? TransactionDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual TbVariation? Variation { get; set; }
}
