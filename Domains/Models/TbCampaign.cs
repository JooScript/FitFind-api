using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbCampaign
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public bool? IsActive { get; set; }
}
