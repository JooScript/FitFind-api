using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbAddress
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string? AddressType { get; set; }

    public string StreetAddress1 { get; set; } = null!;

    public string? StreetAddress2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public bool? IsDefault { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbOrder> TbOrderBillingAddresses { get; set; } = new List<TbOrder>();

    public virtual ICollection<TbOrder> TbOrderShippingAddresses { get; set; } = new List<TbOrder>();

    public virtual ICollection<TbPayment> TbPayments { get; set; } = new List<TbPayment>();

    public virtual AppUser? User { get; set; }
}
