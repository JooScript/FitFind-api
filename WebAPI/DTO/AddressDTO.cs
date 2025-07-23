using ECommerce.Da;

namespace ECommerce.DTO
{
    public class AddressDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string? UserId
        {
            get;
            set;
        }

        public string? AddressType
        {
            get;
            set;
        }

        public string StreetAddress1
        {
            get;
            set;
        }

        public string? StreetAddress2
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public bool? IsDefault
        {
            get;
            set;
        }

        public DateTimeOffset? CreatedAt
        {
            get;
            set;
        }

        public DateTimeOffset? UpdatedAt
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