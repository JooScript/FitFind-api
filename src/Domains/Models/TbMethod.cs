using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbMethod :BaseTable
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Cost { get; set; }

    public string? CalculationMethod { get; set; }

    public virtual ICollection<TbShipment> TbShipments { get; set; } = new List<TbShipment>();
}
