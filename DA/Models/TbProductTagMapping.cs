using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbProductTagMapping
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long TagId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct Product { get; set; } = null!;

    public virtual TbTag Tag { get; set; } = null!;
}
