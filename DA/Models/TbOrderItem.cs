using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbOrderItem
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public long? ProductId { get; set; }

    public long? VariationId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? ItemStatus { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbOrder? Order { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual ICollection<TbOrderReturn> TbOrderReturns { get; set; } = new List<TbOrderReturn>();

    public virtual ICollection<TbShipmentItemMapping> TbShipmentItemMappings { get; set; } = new List<TbShipmentItemMapping>();

    public virtual TbVariation? Variation { get; set; }
}
