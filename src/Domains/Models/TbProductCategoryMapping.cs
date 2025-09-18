using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbProductCategoryMapping :BaseTable
{
    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }

    public bool? IsPrimary { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

    public virtual TbProduct Product { get; set; } = null!;
}
