using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbTag
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbProductTagMapping> TbProductTagMappings { get; set; } = new List<TbProductTagMapping>();
}
