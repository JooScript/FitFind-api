using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbUserActivity :BaseTable
{
    public Guid? UserId { get; set; }

    public string? Action { get; set; }

    public string? Page { get; set; }

    public DateTimeOffset? Timestamp { get; set; }

    public string? IpAddress { get; set; }

}
