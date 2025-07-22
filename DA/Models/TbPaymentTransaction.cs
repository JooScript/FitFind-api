using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbPaymentTransaction
{
    public long Id { get; set; }

    public long? PaymentId { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTimeOffset? TransactionDate { get; set; }

    public string? GatewayTransactionId { get; set; }

    public string Status { get; set; } = null!;

    public string? ResponseCode { get; set; }

    public string? ResponseMessage { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbPayment? Payment { get; set; }
}
