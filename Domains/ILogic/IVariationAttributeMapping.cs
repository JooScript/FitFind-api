using ECommerce.Models;
    public interface IVariationAttributeMapping
    {
public Task<TbVariationAttributeMapping> GetById(long id);
public Task<List<TbVariationAttributeMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbVariationAttributeMapping variationAttributeMapping);
public Task<bool> Update(TbVariationAttributeMapping variationAttributeMapping);
public Task<bool> Save(TbVariationAttributeMapping variationAttributeMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }