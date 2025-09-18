using ECommerce.Domains.Base;
 



namespace ECommerce.Domains.Models;

public partial class TbCampaignProductMapping :BaseTable
{
    public Guid CampaignId { get; set; }

    public Guid ProductId { get; set; }

}
