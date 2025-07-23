using ECommerce.Da;

namespace ECommerce.DTO
{
    public class OrderItemDTO
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

        public long? Product_Id
        {
            get;
            set;
        }

        public long? Variation_Id
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public decimal Unit_price
        {
            get;
            set;
        }

        public decimal Total_price
        {
            get;
            set;
        }

        public decimal? Tax_amount
        {
            get;
            set;
        }

        public decimal? Discount_amount
        {
            get;
            set;
        }

        public string? Item_status
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