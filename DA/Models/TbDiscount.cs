using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbDiscount
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string DiscountType { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    public int? MaxUses { get; set; }

    public int? CurrentUses { get; set; }

    public decimal? MinOrderAmount { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSingleUse { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbDiscountCategoryMapping> TbDiscountCategoryMappings { get; set; } = new List<TbDiscountCategoryMapping>();

    public virtual ICollection<TbDiscountProductMapping> TbDiscountProductMappings { get; set; } = new List<TbDiscountProductMapping>();
}
