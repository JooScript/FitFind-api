using ECommerce.Domains.Base;
 


namespace ECommerce.Domains.Models;

public partial class TbImage :BaseTable
{
    public Guid? ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? AltText { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual TbProduct? Product { get; set; }
}
