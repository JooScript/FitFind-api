using ECommerce.Domains.Base;
 



namespace ECommerce.Domains.Models;

public partial class TbCampaign :BaseTable
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

}
