using ECommerce.Models;
    public interface IReview
    {
public Task<TbReview> GetById(long id);
public Task<List<TbReview>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbReview review);
public Task<bool> Update(TbReview review);
public Task<bool> Save(TbReview review);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }