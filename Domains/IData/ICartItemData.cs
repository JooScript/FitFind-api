using ECommerce.Models;
    public interface ICartItemData
    {
public Task<TbCartItem> GetById(long id);
public Task<List<TbCartItem>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbCartItem cartItem);
public Task<bool> Update(TbCartItem cartItem);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }