using ECommerce.Domains.Base;

namespace ECommerce.Domains.Models;

public partial class TbAddress : BaseTable

{
    public Guid? UserId { get; set; }

    public string? AddressType { get; set; }

    public string StreetAddress1 { get; set; } = null!;

    public string? StreetAddress2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public bool? IsDefault { get; set; }

    public virtual ICollection<TbOrder> TbOrderBillingAddresses { get; set; } = new List<TbOrder>();

    public virtual ICollection<TbOrder> TbOrderShippingAddresses { get; set; } = new List<TbOrder>();

    public virtual ICollection<TbPayment> TbPayments { get; set; } = new List<TbPayment>();

}
