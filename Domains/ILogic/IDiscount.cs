using ECommerce.Models;
    public interface IDiscount
    {
public Task<TbDiscount> GetById(long id);
public Task<List<TbDiscount>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbDiscount discount);
public Task<bool> Update(TbDiscount discount);
public Task<bool> Save(TbDiscount discount);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }