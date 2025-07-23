using ECommerce.Da;

namespace ECommerce.DTO
{
    public class CategoryDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? ParentCategoryId
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

        public string Slug
        {
            get;
            set;
        }

        public bool? IsActive
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

        public string? ModifiedBy
        {
            get;
            set;
        }

        public DateTimeOffset? ModifiedDate
        {
            get;
            set;
        }


}}