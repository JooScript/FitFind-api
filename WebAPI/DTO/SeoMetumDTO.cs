using ECommerce.Da;

namespace ECommerce.DTO
{
    public class SeoMetumDTO
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

        public string? Meta_title
        {
            get;
            set;
        }

        public string? Meta_description
        {
            get;
            set;
        }

        public string? Meta_keywords
        {
            get;
            set;
        }

        public string? Canonical_url
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