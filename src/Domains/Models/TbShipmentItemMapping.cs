using ECommerce.Domains.Base;
 

namespace ECommerce.Domains.Models;

public partial class TbShipmentItemMapping :BaseTable
{
    public Guid? ShipmentId { get; set; }

    public Guid? OrderItemId { get; set; }

    public int Quantity { get; set; }

    public virtual TbOrderItem? OrderItem { get; set; }

    public virtual TbShipment? Shipment { get; set; }
}
