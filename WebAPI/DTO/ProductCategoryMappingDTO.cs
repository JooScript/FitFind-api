using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ProductCategoryMappingDTO
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

        public long Category_Id
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