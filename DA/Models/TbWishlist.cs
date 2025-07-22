using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbWishlist
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsDefault { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbWishlistItem> TbWishlistItems { get; set; } = new List<TbWishlistItem>();

    public virtual AppUser? User { get; set; }
}
