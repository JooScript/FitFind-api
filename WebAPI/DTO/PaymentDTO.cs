using ECommerce.Da;

namespace ECommerce.DTO
{
    public class PaymentDTO
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

        public string Payment_method
        {
            get;
            set;
        }

        public string? Transaction_Id
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public string? Currency
        {
            get;
            set;
        }

        public string Payment_status
        {
            get;
            set;
        }

        public DateTimeOffset? Payment_date
        {
            get;
            set;
        }

        public string? Gateway_response
        {
            get;
            set;
        }

        public long? Billing_address_Id
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