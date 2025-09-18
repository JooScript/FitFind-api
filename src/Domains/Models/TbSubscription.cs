using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbSubscription :BaseTable
{
    public Guid? UserId { get; set; }

    public Guid? ProductId { get; set; }

    public string? Frequency { get; set; }

    public DateTimeOffset? NextBillingDate { get; set; }

    public string? Status { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public virtual TbProduct? Product { get; set; }

}
