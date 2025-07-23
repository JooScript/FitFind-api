using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbAttribute
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbAttributeValue> TbAttributeValues { get; set; } = new List<TbAttributeValue>();

    public virtual ICollection<TbVariationAttributeMapping> TbVariationAttributeMappings { get; set; } = new List<TbVariationAttributeMapping>();
}
