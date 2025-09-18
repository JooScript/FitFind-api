using ECommerce.Domains.Base;
 



namespace ECommerce.Domains.Models;

public partial class TbCategory :BaseTable
{
    public Guid? ParentCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Slug { get; set; } = null!;

    public int? DisplayOrder { get; set; }

    public virtual ICollection<TbCategory> InverseParentCategory { get; set; } = new List<TbCategory>();

    public virtual TbCategory? ParentCategory { get; set; }

    public virtual ICollection<TbDiscountCategoryMapping> TbDiscountCategoryMappings { get; set; } = new List<TbDiscountCategoryMapping>();

    public virtual ICollection<TbProductCategoryMapping> TbProductCategoryMappings { get; set; } = new List<TbProductCategoryMapping>();
}
