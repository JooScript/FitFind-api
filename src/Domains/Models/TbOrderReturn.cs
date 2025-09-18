using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbOrderReturn :BaseTable
{
    public Guid? OrderItemId { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public DateTimeOffset? RequestedAt { get; set; }

    public DateTimeOffset? ProcessedAt { get; set; }

    public virtual TbOrderItem? OrderItem { get; set; }
}
