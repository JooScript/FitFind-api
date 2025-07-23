using ECommerce.Models;
    public interface IProductSupplierData
    {
public Task<TbProductSupplier> GetById(long id);
public Task<List<TbProductSupplier>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbProductSupplier productSupplier);
public Task<bool> Update(TbProductSupplier productSupplier);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }