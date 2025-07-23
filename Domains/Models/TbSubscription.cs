using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbSubscription
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public long? ProductId { get; set; }

    public string? Frequency { get; set; }

    public DateTimeOffset? NextBillingDate { get; set; }

    public string? Status { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual AppUser? User { get; set; }
}
