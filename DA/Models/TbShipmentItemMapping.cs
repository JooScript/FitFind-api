using System;
using System.Collections.Generic;

namespace ECommerce.Models;

public partial class TbShipmentItemMapping
{
    public long Id { get; set; }

    public long? ShipmentId { get; set; }

    public long? OrderItemId { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TbOrderItem? OrderItem { get; set; }

    public virtual TbShipment? Shipment { get; set; }
}
