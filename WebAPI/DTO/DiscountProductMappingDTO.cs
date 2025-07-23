using ECommerce.Da;

namespace ECommerce.DTO
{
    public class DiscountProductMappingDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long Discount_Id
        {
            get;
            set;
        }

        public long Product_Id
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