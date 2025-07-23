using ECommerce.Models;
    public interface IProductData
    {
public Task<TbProduct> GetById(long id);
public Task<List<TbProduct>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbProduct product);
public Task<bool> Update(TbProduct product);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }