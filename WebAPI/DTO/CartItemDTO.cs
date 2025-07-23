using ECommerce.Da;

namespace ECommerce.DTO
{
    public class CartItemDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? CartId
        {
            get;
            set;
        }

        public long? ProductId
        {
            get;
            set;
        }

        public long? VariationId
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public DateTimeOffset? AddedAt
        {
            get;
            set;
        }


}}