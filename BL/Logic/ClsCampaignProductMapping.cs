using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsCampaignProductMapping : ICampaignProductMapping
    {
        CampaignProductMappingData oCampaignProductMappingData;

        public ClsCampaignProductMapping(ECommerceContext context)
        {
            oCampaignProductMappingData = new CampaignProductMappingData(context);
        }
               public async Task<TbCampaignProductMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var campaignProductMapping = await oCampaignProductMappingData.GetById(id);
                return campaignProductMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbCampaignProductMapping campaignProductMapping)
        {
              long campaignProductMappingId = -1;
            try
            {
                campaignProductMappingId = await oCampaignProductMappingData.Add(campaignProductMapping);
                return campaignProductMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbCampaignProductMapping campaignProductMapping)
        {
            try
            {
                return await oCampaignProductMappingData.Update(campaignProductMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbCampaignProductMapping campaignProductMapping) => campaignProductMapping.Id <= 0 ? await Add(campaignProductMapping) != -1 : await Update(campaignProductMapping);
        public async Task<List<TbCampaignProductMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oCampaignProductMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oCampaignProductMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oCampaignProductMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oCampaignProductMappingData.Delete(id);
        }

    }
}