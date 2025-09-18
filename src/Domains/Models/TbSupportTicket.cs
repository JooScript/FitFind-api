using ECommerce.Domains.Base;
using static ECommerce.Core.Enums.Status;


namespace ECommerce.Domains.Models;

public partial class TbSupportTicket : BaseTable
{
    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;

    public enPriorityLevel Priority { get; set; } = enPriorityLevel.Medium;

    public Guid? AssignedTo { get; set; }

    public virtual ICollection<TbTicketReply> TbTicketReplies { get; set; } = new List<TbTicketReply>();

}
