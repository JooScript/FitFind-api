using ECommerce.Models;
    public interface IProductCategoryMapping
    {
public Task<TbProductCategoryMapping> GetById(long id);
public Task<List<TbProductCategoryMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbProductCategoryMapping productCategoryMapping);
public Task<bool> Update(TbProductCategoryMapping productCategoryMapping);
public Task<bool> Save(TbProductCategoryMapping productCategoryMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }