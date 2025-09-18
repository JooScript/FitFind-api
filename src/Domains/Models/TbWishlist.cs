using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbWishlist :BaseTable
{
    public Guid? UserId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDefault { get; set; }

    public virtual ICollection<TbWishlistItem> TbWishlistItems { get; set; } = new List<TbWishlistItem>();

}
