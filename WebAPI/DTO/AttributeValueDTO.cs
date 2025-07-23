using ECommerce.Da;

namespace ECommerce.DTO
{
    public class AttributeValueDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? AttributeId
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public int? DisplayOrder
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