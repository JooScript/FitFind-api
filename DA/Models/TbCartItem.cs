using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbCartItem
{
    public long ItemId { get; set; }

    public long? CartId { get; set; }

    public long? ProductId { get; set; }

    public long? VariationId { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? AddedAt { get; set; }

    public virtual TbShoppingCart? Cart { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual TbVariation? Variation { get; set; }
}
