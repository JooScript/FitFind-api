using ECommerce.Da;

namespace ECommerce.DTO
{
    public class OrderStatusHistoryDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Order_Id
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public DateTimeOffset? Status_date
        {
            get;
            set;
        }

        public string? Comments
        {
            get;
            set;
        }

        public string? User_Id
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