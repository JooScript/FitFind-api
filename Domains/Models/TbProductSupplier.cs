using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbProductSupplier
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long SupplierId { get; set; }

    public decimal CostPrice { get; set; }

    public int? LeadTimeDays { get; set; }

    public bool? IsPrimary { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct Product { get; set; } = null!;

    public virtual TbSupplier Supplier { get; set; } = null!;
}
