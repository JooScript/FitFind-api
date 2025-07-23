using ECommerce.Da;

namespace ECommerce.DTO
{
    public class WishlistItemDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Wishlist_Id
        {
            get;
            set;
        }

        public long? Product_Id
        {
            get;
            set;
        }

        public DateTimeOffset? Added_at
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