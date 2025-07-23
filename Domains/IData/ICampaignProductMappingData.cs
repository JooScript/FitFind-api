using ECommerce.Models;
    public interface ICampaignProductMappingData
    {
public Task<TbCampaignProductMapping> GetById(long id);
public Task<List<TbCampaignProductMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbCampaignProductMapping campaignProductMapping);
public Task<bool> Update(TbCampaignProductMapping campaignProductMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }