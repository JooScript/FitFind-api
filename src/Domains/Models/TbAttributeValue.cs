using ECommerce.Domains.Base;



namespace ECommerce.Domains.Models;

public partial class TbAttributeValue : BaseTable
{
    public Guid? AttributeId { get; set; }

    public string Value { get; set; } = null!;

    public int? DisplayOrder { get; set; }

    public virtual TbAttribute? Attribute { get; set; }

    public virtual ICollection<TbVariationAttributeMapping> TbVariationAttributeMappings { get; set; } = new List<TbVariationAttributeMapping>();
}
