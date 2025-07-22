using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbPayment
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

    public decimal Amount { get; set; }

    public string? Currency { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public DateTimeOffset? PaymentDate { get; set; }

    public string? GatewayResponse { get; set; }

    public long? BillingAddressId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbAddress? BillingAddress { get; set; }

    public virtual TbOrder? Order { get; set; }

    public virtual ICollection<TbPaymentTransaction> TbPaymentTransactions { get; set; } = new List<TbPaymentTransaction>();
}
