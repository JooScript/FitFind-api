using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbShipment :BaseTable
{
    public Guid? OrderId { get; set; }

    public Guid? ShippingMethodId { get; set; }

    public string? TrackingNumber { get; set; }

    public string? Carrier { get; set; }

    public DateTimeOffset? ShipmentDate { get; set; }

    public DateTimeOffset? EstimatedDeliveryDate { get; set; }

    public DateTimeOffset? ActualDeliveryDate { get; set; }

    public string? ShipmentStatus { get; set; }

    public decimal ShippingCost { get; set; }

    public virtual TbOrder? Order { get; set; }

    public virtual TbMethod? ShippingMethod { get; set; }

    public virtual ICollection<TbShipmentItemMapping> TbShipmentItemMappings { get; set; } = new List<TbShipmentItemMapping>();
}
