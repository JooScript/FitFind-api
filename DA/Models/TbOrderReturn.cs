using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbOrderReturn
{
    public long Id { get; set; }

    public long? OrderItemId { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? RequestedAt { get; set; }

    public DateTimeOffset? ProcessedAt { get; set; }

    public virtual TbOrderItem? OrderItem { get; set; }
}
