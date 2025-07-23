using ECommerce.Da;

namespace ECommerce.DTO
{
    public class TicketReplyDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Ticket_Id
        {
            get;
            set;
        }

        public string? User_Id
        {
            get;
            set;
        }

        public string? Message
        {
            get;
            set;
        }

        public DateTimeOffset? Replied_at
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