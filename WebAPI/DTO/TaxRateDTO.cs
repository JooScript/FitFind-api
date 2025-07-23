using ECommerce.Da;

namespace ECommerce.DTO
{
    public class TaxRateDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public string? State
        {
            get;
            set;
        }

        public string? Zip_code
        {
            get;
            set;
        }

        public decimal Rate
        {
            get;
            set;
        }

        public string Tax_name
        {
            get;
            set;
        }

        public bool? Is_active
        {
            get;
            set;
        }

        public bool? Is_default
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