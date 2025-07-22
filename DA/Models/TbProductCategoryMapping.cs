using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbProductCategoryMapping
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long CategoryId { get; set; }

    public bool? IsPrimary { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;
}
