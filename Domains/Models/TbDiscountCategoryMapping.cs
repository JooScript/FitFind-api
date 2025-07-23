using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbDiscountCategoryMapping
{
    public long Id { get; set; }

    public long DiscountId { get; set; }

    public long CategoryId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

    public virtual TbDiscount Discount { get; set; } = null!;
}
