using ECommerce.Da;

namespace ECommerce.DTO
{
    public class DiscountCategoryMappingDTO
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

        public long Category_Id
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