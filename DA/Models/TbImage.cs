using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbImage
{
    public long Id { get; set; }

    public long? ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? AltText { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsPrimary { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct? Product { get; set; }
}
