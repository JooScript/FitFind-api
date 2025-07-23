using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ProductSupplierDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long Product_Id
        {
            get;
            set;
        }

        public long Supplier_Id
        {
            get;
            set;
        }

        public decimal Cost_price
        {
            get;
            set;
        }

        public int? Lead_time_days
        {
            get;
            set;
        }

        public bool? Is_primary
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