using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbCampaignProductMapping
{
    public long Id { get; set; }

    public long CampaignId { get; set; }

    public long ProductId { get; set; }

    public bool IsDeleted { get; set; }

}
