using ECommerce.Da;

namespace ECommerce.DTO
{
    public class SubscriptionDTO
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

        public long? Product_Id
        {
            get;
            set;
        }

        public string? Frequency
        {
            get;
            set;
        }

        public DateTimeOffset? Next_billing_date
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

        public bool IsDeleted
        {
            get;
            set;
        }


}}