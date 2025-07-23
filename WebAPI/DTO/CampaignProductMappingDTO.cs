using ECommerce.Da;

namespace ECommerce.DTO
{
    public class CampaignProductMappingDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long CampaignId
        {
            get;
            set;
        }

        public long ProductId
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