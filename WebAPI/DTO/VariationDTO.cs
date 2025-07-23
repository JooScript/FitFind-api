using ECommerce.Da;

namespace ECommerce.DTO
{
    public class VariationDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Product_Id
        {
            get;
            set;
        }

        public string Sku
        {
            get;
            set;
        }

        public string Variation_name
        {
            get;
            set;
        }

        public decimal? Price_adjustment
        {
            get;
            set;
        }

        public int? Stock_quantity
        {
            get;
            set;
        }

        public bool? Is_active
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