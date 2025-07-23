using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbInventoryTransaction
{
    public long Id { get; set; }

    public long? ProductId { get; set; }

    public long? VariationId { get; set; }

    public int QuantityChange { get; set; }

    public string TransactionType { get; set; } = null!;

    public long? ReferenceId { get; set; }

    public string? ReferenceType { get; set; }

    public string? Notes { get; set; }

    public DateTimeOffset? TransactionDate { get; set; }

    public string? UserId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual AppUser? User { get; set; }

    public virtual TbVariation? Variation { get; set; }
}
