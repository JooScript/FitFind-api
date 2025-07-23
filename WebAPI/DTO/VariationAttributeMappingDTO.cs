using ECommerce.Da;

namespace ECommerce.DTO
{
    public class VariationAttributeMappingDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long Variation_Id
        {
            get;
            set;
        }

        public long Attribute_Id
        {
            get;
            set;
        }

        public long? Value_Id
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