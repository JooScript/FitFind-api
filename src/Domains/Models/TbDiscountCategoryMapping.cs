 
using System;
using System.Collections.Generic;
using ECommerce.Domains.Base;

namespace ECommerce.Domains.Models;

public partial class TbDiscountCategoryMapping :BaseTable
{
    public Guid DiscountId { get; set; }

    public Guid CategoryId { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

    public virtual TbDiscount Discount { get; set; } = null!;
}
