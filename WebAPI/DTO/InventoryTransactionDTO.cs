using ECommerce.Da;

namespace ECommerce.DTO
{
    public class InventoryTransactionDTO
    {
        public long Id
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

        public int Quantity_change
        {
            get;
            set;
        }

        public string Transaction_type
        {
            get;
            set;
        }

        public long? Reference_Id
        {
            get;
            set;
        }

        public string? Reference_type
        {
            get;
            set;
        }

        public string? Notes
        {
            get;
            set;
        }

        public DateTimeOffset? Transaction_date
        {
            get;
            set;
        }

        public string? User_Id
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