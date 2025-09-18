using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbPaymentTransaction :BaseTable
{
    public Guid? PaymentId { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTimeOffset? TransactionDate { get; set; }

    public string? GatewayTransactionId { get; set; }

    public string? ResponseCode { get; set; }

    public string? ResponseMessage { get; set; }

    public virtual TbPayment? Payment { get; set; }
}
