using ECommerce.Domains.Base;

namespace ECommerce.Domains.Models;

public partial class TbAttribute : BaseTable
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TbAttributeValue> TbAttributeValues { get; set; } = new List<TbAttributeValue>();

    public virtual ICollection<TbVariationAttributeMapping> TbVariationAttributeMappings { get; set; } = new List<TbVariationAttributeMapping>();
}
