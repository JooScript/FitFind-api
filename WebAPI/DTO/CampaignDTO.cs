using ECommerce.Da;

namespace ECommerce.DTO
{
    public class CampaignDTO
    {
        public long Id
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

        public bool IsDeleted
        {
            get;
            set;
        }

        public DateTimeOffset? StartDate
        {
            get;
            set;
        }

        public DateTimeOffset? EndDate
        {
            get;
            set;
        }

        public bool? IsActive
        {
            get;
            set;
        }


}}