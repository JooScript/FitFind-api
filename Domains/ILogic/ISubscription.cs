using ECommerce.Models;
    public interface ISubscription
    {
public Task<TbSubscription> GetById(long id);
public Task<List<TbSubscription>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbSubscription subscription);
public Task<bool> Update(TbSubscription subscription);
public Task<bool> Save(TbSubscription subscription);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }