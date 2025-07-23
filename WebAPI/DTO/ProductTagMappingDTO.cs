using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ProductTagMappingDTO
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

        public long Tag_Id
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