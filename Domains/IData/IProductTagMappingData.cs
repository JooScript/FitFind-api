using ECommerce.Models;
    public interface IProductTagMappingData
    {
public Task<TbProductTagMapping> GetById(long id);
public Task<List<TbProductTagMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbProductTagMapping productTagMapping);
public Task<bool> Update(TbProductTagMapping productTagMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }