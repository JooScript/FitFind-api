using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ProductDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string Sku
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string? Description
        {
            get;
            set;
        }

        public string? Short_description
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public decimal? Cost_price
        {
            get;
            set;
        }

        public decimal? Weight
        {
            get;
            set;
        }

        public decimal? Length
        {
            get;
            set;
        }

        public decimal? Width
        {
            get;
            set;
        }

        public decimal? Height
        {
            get;
            set;
        }

        public bool? Is_active
        {
            get;
            set;
        }

        public bool? Is_digital
        {
            get;
            set;
        }

        public int? Stock_quantity
        {
            get;
            set;
        }

        public int? Low_stock_threshold
        {
            get;
            set;
        }

        public bool IsDeleted
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


}}