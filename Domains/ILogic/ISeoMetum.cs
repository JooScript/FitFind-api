using ECommerce.Models;
    public interface ISeoMetum
    {
public Task<TbSeoMetum> GetById(long id);
public Task<List<TbSeoMetum>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbSeoMetum seoMetum);
public Task<bool> Update(TbSeoMetum seoMetum);
public Task<bool> Save(TbSeoMetum seoMetum);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }