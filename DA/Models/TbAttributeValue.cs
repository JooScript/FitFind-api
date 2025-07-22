using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbAttributeValue
{
    public long Id { get; set; }

    public long? AttributeId { get; set; }

    public string Value { get; set; } = null!;

    public int? DisplayOrder { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbAttribute? Attribute { get; set; }

    public virtual ICollection<TbVariationAttributeMapping> TbVariationAttributeMappings { get; set; } = new List<TbVariationAttributeMapping>();
}
