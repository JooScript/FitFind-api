using ECommerce.Domains.Base;

namespace ECommerce.Domains.Models;

public partial class TbInvoice : BaseTable
{
    public Guid? OrderId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTimeOffset? IssuedDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? TaxAmount { get; set; }

    public DateTimeOffset? DueDate { get; set; }

    public virtual TbOrder? Order { get; set; }
}
