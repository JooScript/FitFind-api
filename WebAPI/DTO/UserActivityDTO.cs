using ECommerce.Da;

namespace ECommerce.DTO
{
    public class UserActivityDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string? User_Id
        {
            get;
            set;
        }

        public string? Action
        {
            get;
            set;
        }

        public string? Page
        {
            get;
            set;
        }

        public DateTimeOffset? Timestamp
        {
            get;
            set;
        }

        public string? Ip_address
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