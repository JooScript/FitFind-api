using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbAuditLog
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string Action { get; set; } = null!;

    public string? Entity { get; set; }

    public long? EntityId { get; set; }

    public string? Details { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? LogDate { get; set; }

    public virtual AppUser? User { get; set; }
}
