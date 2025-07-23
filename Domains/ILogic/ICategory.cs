using ECommerce.Models;
    public interface ICategory
    {
public Task<TbCategory> GetById(long id);
public Task<List<TbCategory>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbCategory category);
public Task<bool> Update(TbCategory category);
public Task<bool> Save(TbCategory category);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }