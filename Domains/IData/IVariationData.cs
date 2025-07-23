using ECommerce.Models;
    public interface IVariationData
    {
public Task<TbVariation> GetById(long id);
public Task<List<TbVariation>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbVariation variation);
public Task<bool> Update(TbVariation variation);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }