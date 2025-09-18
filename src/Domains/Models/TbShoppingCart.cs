using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbShoppingCart :BaseTable
{
    public Guid? UserId { get; set; }

    public string? SessionId { get; set; }

    public virtual ICollection<TbCartItem> TbCartItems { get; set; } = new List<TbCartItem>();

}
