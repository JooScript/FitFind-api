using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbTicketReply
{
    public long Id { get; set; }

    public long? TicketId { get; set; }

    public string? UserId { get; set; }

    public string? Message { get; set; }

    public DateTimeOffset? RepliedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbSupportTicket? Ticket { get; set; }

    public virtual AppUser? User { get; set; }
}
