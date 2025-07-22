using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbDiscountProductMapping
{
    public long MapId { get; set; }

    public long DiscountId { get; set; }

    public long ProductId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbDiscount Discount { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;
}
