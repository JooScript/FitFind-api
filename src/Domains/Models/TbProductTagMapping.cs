using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbProductTagMapping :BaseTable
{
    public Guid ProductId { get; set; }

    public Guid TagId { get; set; }

    public virtual TbProduct Product { get; set; } = null!;

    public virtual TbTag Tag { get; set; } = null!;
}
