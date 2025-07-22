using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbVariationAttributeMapping
{
    public long Id { get; set; }

    public long VariationId { get; set; }

    public long AttributeId { get; set; }

    public long? ValueId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbAttribute Attribute { get; set; } = null!;

    public virtual TbAttributeValue? Value { get; set; }

    public virtual TbVariation Variation { get; set; } = null!;
}
