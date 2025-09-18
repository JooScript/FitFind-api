using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbTicketReply :BaseTable
{
    public Guid? TicketId { get; set; }

    public Guid? UserId { get; set; }

    public string? Message { get; set; }

    public DateTimeOffset? RepliedAt { get; set; }

    public virtual TbSupportTicket? Ticket { get; set; }

}
