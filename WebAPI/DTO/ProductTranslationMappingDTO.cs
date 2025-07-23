using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ProductTranslationMappingDTO
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

        public string? Name
        {
            get;
            set;
        }

        public string? Description
        {
            get;
            set;
        }

        public string? Short_description
        {
            get;
            set;
        }

        public int Language_Id
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