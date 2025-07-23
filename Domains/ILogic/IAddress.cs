using ECommerce.Models;
    public interface IAddress
    {
public Task<TbAddress> GetById(long id);
public Task<List<TbAddress>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbAddress address);
public Task<bool> Update(TbAddress address);
public Task<bool> Save(TbAddress address);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }