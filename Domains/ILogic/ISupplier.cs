using ECommerce.Models;
    public interface ISupplier
    {
public Task<TbSupplier> GetById(long id);
public Task<List<TbSupplier>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbSupplier supplier);
public Task<bool> Update(TbSupplier supplier);
public Task<bool> Save(TbSupplier supplier);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }