using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbTaxRate :BaseTable
{
    public string Country { get; set; } = null!;

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public decimal Rate { get; set; }

    public string TaxName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsDefault { get; set; }

}
