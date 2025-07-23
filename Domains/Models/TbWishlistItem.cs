using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbWishlistItem
{
    public long Id { get; set; }

    public long? WishlistId { get; set; }

    public long? ProductId { get; set; }

    public DateTimeOffset? AddedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual TbWishlist? Wishlist { get; set; }
}
