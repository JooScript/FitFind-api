using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbTaxRate
{
    public long Id { get; set; }

    public string Country { get; set; } = null!;

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public decimal Rate { get; set; }

    public string TaxName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDefault { get; set; }

    public bool IsDeleted { get; set; }
}
