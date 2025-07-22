using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbReview
{
    public long Id { get; set; }

    public long? ProductId { get; set; }

    public string? UserId { get; set; }

    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? Comment { get; set; }

    public DateTimeOffset? ReviewDate { get; set; }

    public bool? IsApproved { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbProduct? Product { get; set; }

    public virtual AppUser? User { get; set; }
}
