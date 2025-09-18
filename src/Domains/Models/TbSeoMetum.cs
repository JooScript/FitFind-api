using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbSeoMetum :BaseTable
{
    public Guid ProductId { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public string? MetaKeywords { get; set; }

    public string? CanonicalUrl { get; set; }

    public virtual TbProduct Product { get; set; } = null!;
}
