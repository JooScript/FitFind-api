using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbInvoice
{
    public long Id { get; set; }

    public long? OrderId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTimeOffset? IssuedDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal? TaxAmount { get; set; }



    public DateTimeOffset? DueDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbOrder? Order { get; set; }
}
