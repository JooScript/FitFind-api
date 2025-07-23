using ECommerce.Da;

namespace ECommerce.DTO
{
    public class AttributeDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string? Description
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