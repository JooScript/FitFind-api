using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ShipmentDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Order_Id
        {
            get;
            set;
        }

        public long? Shipping_method_Id
        {
            get;
            set;
        }

        public string? Tracking_number
        {
            get;
            set;
        }

        public string? Carrier
        {
            get;
            set;
        }

        public DateTimeOffset? Shipment_date
        {
            get;
            set;
        }

        public DateTimeOffset? Estimated_delivery_date
        {
            get;
            set;
        }

        public DateTimeOffset? Actual_delivery_date
        {
            get;
            set;
        }

        public string? Shipment_status
        {
            get;
            set;
        }

        public decimal Shipping_cost
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