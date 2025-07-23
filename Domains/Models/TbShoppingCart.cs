using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbShoppingCart
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbCartItem> TbCartItems { get; set; } = new List<TbCartItem>();

    public virtual AppUser? User { get; set; }
}
