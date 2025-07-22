using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbOrderStatusHistory
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public string Status { get; set; } = null!;

    public DateTimeOffset? StatusDate { get; set; }

    public string? Comments { get; set; }

    public string? UserId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbOrder? Order { get; set; }

    public virtual AppUser? User { get; set; }
}
