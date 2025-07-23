using ECommerce.Models;
    public interface IOrderStatusHistoryData
    {
public Task<TbOrderStatusHistory> GetById(long id);
public Task<List<TbOrderStatusHistory>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbOrderStatusHistory orderStatusHistory);
public Task<bool> Update(TbOrderStatusHistory orderStatusHistory);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }