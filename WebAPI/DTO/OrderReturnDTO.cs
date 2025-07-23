using ECommerce.Da;

namespace ECommerce.DTO
{
    public class OrderReturnDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Order_item_Id
        {
            get;
            set;
        }

        public string? Reason
        {
            get;
            set;
        }

        public string? Status
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public DateTimeOffset? Requested_at
        {
            get;
            set;
        }

        public DateTimeOffset? Processed_at
        {
            get;
            set;
        }


}}