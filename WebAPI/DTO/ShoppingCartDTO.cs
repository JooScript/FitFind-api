using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ShoppingCartDTO
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

        public string? Session_Id
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

        public bool IsDeleted
        {
            get;
            set;
        }


}}