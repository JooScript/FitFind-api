using ECommerce.Da;

namespace ECommerce.DTO
{
    public class SupplierDTO
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

        public string? Contact_person
        {
            get;
            set;
        }

        public string? Email
        {
            get;
            set;
        }

        public string? Phone
        {
            get;
            set;
        }

        public string? Address
        {
            get;
            set;
        }

        public bool? Is_active
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