using ECommerce.Models;
    public interface IOrderReturnData
    {
public Task<TbOrderReturn> GetById(long id);
public Task<List<TbOrderReturn>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbOrderReturn orderReturn);
public Task<bool> Update(TbOrderReturn orderReturn);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }