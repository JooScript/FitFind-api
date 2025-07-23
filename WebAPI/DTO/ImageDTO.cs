using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ImageDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Product_Id
        {
            get;
            set;
        }

        public string Image_url
        {
            get;
            set;
        }

        public string? AltText
        {
            get;
            set;
        }

        public int? DisplayOrder
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