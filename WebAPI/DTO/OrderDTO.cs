using ECommerce.Da;

namespace ECommerce.DTO
{
    public class OrderDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string? User_Id
        {
            get;
            set;
        }

        public string Order_number
        {
            get;
            set;
        }

        public string Order_status
        {
            get;
            set;
        }

        public DateTimeOffset? Order_date
        {
            get;
            set;
        }

        public decimal Total_amount
        {
            get;
            set;
        }

        public decimal? Tax_amount
        {
            get;
            set;
        }

        public decimal? Shipping_amount
        {
            get;
            set;
        }

        public decimal? Discount_amount
        {
            get;
            set;
        }

        public string? Payment_method
        {
            get;
            set;
        }

        public string? Shipping_method
        {
            get;
            set;
        }

        public long? Billing_address_Id
        {
            get;
            set;
        }

        public long? Shipping_address_Id
        {
            get;
            set;
        }

        public string? Notes
        {
            get;
            set;
        }

        public string? Ip_address
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