using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbCategory
{
    public long Id { get; set; }

    public long? ParentCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Slug { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? DisplayOrder { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbCategory> InverseParentCategory { get; set; } = new List<TbCategory>();

    public virtual TbCategory? ParentCategory { get; set; }

    public virtual ICollection<TbDiscountCategoryMapping> TbDiscountCategoryMappings { get; set; } = new List<TbDiscountCategoryMapping>();

    public virtual ICollection<TbProductCategoryMapping> TbProductCategoryMappings { get; set; } = new List<TbProductCategoryMapping>();
}
