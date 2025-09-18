using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbWishlistItem :BaseTable
{
    public Guid? WishlistId { get; set; }

    public Guid? ProductId { get; set; }

    public DateTimeOffset? AddedAt { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual TbWishlist? Wishlist { get; set; }
}
