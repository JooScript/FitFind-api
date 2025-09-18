using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbVariationAttributeMapping :BaseTable
{
    public Guid VariationId { get; set; }

    public Guid AttributeId { get; set; }

    public Guid? ValueId { get; set; }

    public virtual TbAttribute Attribute { get; set; } = null!;

    public virtual TbAttributeValue? Value { get; set; }

    public virtual TbVariation Variation { get; set; } = null!;
}
