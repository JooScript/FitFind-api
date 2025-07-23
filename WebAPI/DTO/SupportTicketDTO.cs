using ECommerce.Da;

namespace ECommerce.DTO
{
    public class SupportTicketDTO
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

        public string? Subject
        {
            get;
            set;
        }

        public string? Message
        {
            get;
            set;
        }

        public string? Status
        {
            get;
            set;
        }

        public DateTimeOffset? Created_at
        {
            get;
            set;
        }

        public DateTimeOffset? Updated_at
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