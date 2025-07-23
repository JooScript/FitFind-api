using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbSupportTicket
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public string? Status { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbTicketReply> TbTicketReplies { get; set; } = new List<TbTicketReply>();

    public virtual AppUser? User { get; set; }
}
