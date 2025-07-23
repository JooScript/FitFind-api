using ECommerce.Da;

namespace ECommerce.DTO
{
    public class PaymentTransactionDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Payment_Id
        {
            get;
            set;
        }

        public string Transaction_type
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public DateTimeOffset? Transaction_date
        {
            get;
            set;
        }

        public string? Gateway_transaction_Id
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string? Response_code
        {
            get;
            set;
        }

        public string? Response_message
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