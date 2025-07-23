using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsCampaign : ICampaign
    {
        CampaignData oCampaignData;

        public ClsCampaign(ECommerceContext context)
        {
            oCampaignData = new CampaignData(context);
        }
               public async Task<TbCampaign> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var campaign = await oCampaignData.GetById(id);
                return campaign;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbCampaign campaign)
        {
              long campaignId = -1;
            try
            {
                campaignId = await oCampaignData.Add(campaign);
                return campaignId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbCampaign campaign)
        {
            try
            {
                return await oCampaignData.Update(campaign);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbCampaign campaign) => campaign.Id <= 0 ? await Add(campaign) != -1 : await Update(campaign);
        public async Task<List<TbCampaign>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oCampaignData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oCampaignData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oCampaignData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oCampaignData.Delete(id);
        }

    }
}