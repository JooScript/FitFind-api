using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbOrder
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public string OrderStatus { get; set; } = null!;

    public DateTimeOffset? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? ShippingAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? ShippingMethod { get; set; }

    public long? BillingAddressId { get; set; }

    public long? ShippingAddressId { get; set; }

    public string? Notes { get; set; }

    public string? IpAddress { get; set; }

    public virtual TbAddress? BillingAddress { get; set; }

    public virtual TbAddress? ShippingAddress { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();

    public virtual ICollection<TbOrderItem> TbOrderItems { get; set; } = new List<TbOrderItem>();

    public virtual ICollection<TbOrderStatusHistory> TbOrderStatusHistories { get; set; } = new List<TbOrderStatusHistory>();

    public virtual ICollection<TbPayment> TbPayments { get; set; } = new List<TbPayment>();

    public virtual ICollection<TbShipment> TbShipments { get; set; } = new List<TbShipment>();

    public virtual AppUser? User { get; set; }
}
