using ECommerce.Models;
    public interface IMethodData
    {
public Task<TbMethod> GetById(long id);
public Task<List<TbMethod>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbMethod method);
public Task<bool> Update(TbMethod method);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }