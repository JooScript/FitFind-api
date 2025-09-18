using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbOrderStatusHistory :BaseTable
{
    public Guid? OrderId { get; set; }

    public DateTimeOffset? StatusDate { get; set; }

    public string? Comments { get; set; }

    public Guid? UserId { get; set; }

    public virtual TbOrder? Order { get; set; }

}
