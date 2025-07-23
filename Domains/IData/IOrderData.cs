using ECommerce.Models;
    public interface IOrderData
    {
public Task<TbOrder> GetById(long id);
public Task<List<TbOrder>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbOrder order);
public Task<bool> Update(TbOrder order);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }