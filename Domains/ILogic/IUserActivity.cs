using ECommerce.Models;
    public interface IUserActivity
    {
public Task<TbUserActivity> GetById(long id);
public Task<List<TbUserActivity>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbUserActivity userActivity);
public Task<bool> Update(TbUserActivity userActivity);
public Task<bool> Save(TbUserActivity userActivity);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }