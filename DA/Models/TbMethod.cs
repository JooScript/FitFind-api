using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbMethod
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public decimal? Cost { get; set; }

    public string? CalculationMethod { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<TbShipment> TbShipments { get; set; } = new List<TbShipment>();
}
