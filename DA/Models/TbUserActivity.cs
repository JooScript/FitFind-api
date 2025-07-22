using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbUserActivity
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string? Action { get; set; }

    public string? Page { get; set; }

    public DateTimeOffset? Timestamp { get; set; }

    public string? IpAddress { get; set; }

    public bool IsDeleted { get; set; }

    public virtual AppUser? User { get; set; }
}
