using ECommerce.Models;
    public interface IImage
    {
public Task<TbImage> GetById(long id);
public Task<List<TbImage>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbImage image);
public Task<bool> Update(TbImage image);
public Task<bool> Save(TbImage image);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }