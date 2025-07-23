using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbSeoMetum
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? CanonicalUrl { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct Product { get; set; } = null!;
}
