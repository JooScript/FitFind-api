using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbPayment :BaseTable
{
    public Guid? OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

    public decimal Amount { get; set; }

    public string? Currency { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public DateTimeOffset? PaymentDate { get; set; }

    public string? GatewayResponse { get; set; }

    public Guid? BillingAddressId { get; set; }

    public virtual TbAddress? BillingAddress { get; set; }

    public virtual TbOrder? Order { get; set; }

    public virtual ICollection<TbPaymentTransaction> TbPaymentTransactions { get; set; } = new List<TbPaymentTransaction>();
}
