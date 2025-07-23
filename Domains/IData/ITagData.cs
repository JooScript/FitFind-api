using ECommerce.Models;
    public interface ITagData
    {
public Task<TbTag> GetById(long id);
public Task<List<TbTag>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbTag tag);
public Task<bool> Update(TbTag tag);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }