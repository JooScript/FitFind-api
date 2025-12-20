using ECommerce.Domains.Base;

namespace ECommerce.Domains.Models;

public partial class TbAuditLog : BaseTable
{
    public string Action { get; set; } = null!;

    public string? Entity { get; set; }

    public Guid? EntityId { get; set; }

    public string? Details { get; set; }

}
