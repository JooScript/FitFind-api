using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbReview :BaseTable
{
    public Guid? ProductId { get; set; }

    public Guid? UserId { get; set; }

    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? Comment { get; set; }

    public DateTimeOffset? ReviewDate { get; set; }

    public bool? IsApproved { get; set; }

    public virtual TbProduct? Product { get; set; }

}
