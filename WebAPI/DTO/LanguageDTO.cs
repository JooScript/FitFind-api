using ECommerce.Da;

namespace ECommerce.DTO
{
    public class LanguageDTO
    {
        public int Id
        {
            get;
            set;
        }

        public string Language_code
        {
            get;
            set;
        }

        public string? Name
        {
            get;
            set;
        }

        public bool? Is_default
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