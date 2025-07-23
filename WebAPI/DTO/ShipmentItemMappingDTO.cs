using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ShipmentItemMappingDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Shipment_Id
        {
            get;
            set;
        }

        public long? Order_item_Id
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }


}}