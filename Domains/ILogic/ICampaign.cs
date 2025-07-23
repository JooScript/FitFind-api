using ECommerce.Models;
    public interface ICampaign
    {
public Task<TbCampaign> GetById(long id);
public Task<List<TbCampaign>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbCampaign campaign);
public Task<bool> Update(TbCampaign campaign);
public Task<bool> Save(TbCampaign campaign);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }