using ECommerce.Models;
    public interface IOrderItem
    {
public Task<TbOrderItem> GetById(long id);
public Task<List<TbOrderItem>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbOrderItem orderItem);
public Task<bool> Update(TbOrderItem orderItem);
public Task<bool> Save(TbOrderItem orderItem);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }