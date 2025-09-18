using ECommerce.Domains.Base;

namespace ECommerce.Domains.Models;

public partial class TbOrder : BaseTable
{
    public Guid? UserId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public string OrderStatus { get; set; } = null!;

    public DateTimeOffset? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? ShippingAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? ShippingMethod { get; set; }

    public Guid? BillingAddressId { get; set; }

    public Guid? ShippingAddressId { get; set; }

    public string? Notes { get; set; }

    public string? IpAddress { get; set; }

    #region Navigation Properties

    #region Foreign Keys

    public virtual TbAddress? BillingAddress { get; set; }

    public virtual TbAddress? ShippingAddress { get; set; }

    #endregion

    #region Many to One

    public virtual ICollection<TbInvoice> TbInvoices { get; set; } = new List<TbInvoice>();

    public virtual ICollection<TbOrderItem> TbOrderItems { get; set; } = new List<TbOrderItem>();

    public virtual ICollection<TbOrderStatusHistory> TbOrderStatusHistories { get; set; } = new List<TbOrderStatusHistory>();

    public virtual ICollection<TbPayment> TbPayments { get; set; } = new List<TbPayment>();

    public virtual ICollection<TbShipment> TbShipments { get; set; } = new List<TbShipment>();

    #endregion

    #endregion
}
