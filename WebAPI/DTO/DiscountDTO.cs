using ECommerce.Da;

namespace ECommerce.DTO
{
    public class DiscountDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string Code
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

        public string DiscountType
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public DateTimeOffset StartDate
        {
            get;
            set;
        }

        public DateTimeOffset EndDate
        {
            get;
            set;
        }

        public int? MaxUses
        {
            get;
            set;
        }

        public int? CurrentUses
        {
            get;
            set;
        }

        public decimal? MinOrderAmount
        {
            get;
            set;
        }

        public bool? IsActive
        {
            get;
            set;
        }

        public bool? IsSingleUse
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