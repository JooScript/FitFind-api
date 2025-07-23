using ECommerce.Da;

namespace ECommerce.DTO
{
    public class InvoiceDTO
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

        public string Invoice_number
        {
            get;
            set;
        }

        public DateTimeOffset? Issued_date
        {
            get;
            set;
        }

        public decimal Total_amount
        {
            get;
            set;
        }

        public decimal? Tax_amount
        {
            get;
            set;
        }

        public DateTimeOffset? Due_date
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