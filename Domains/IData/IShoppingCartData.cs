using ECommerce.Models;
    public interface IShoppingCartData
    {
public Task<TbShoppingCart> GetById(long id);
public Task<List<TbShoppingCart>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbShoppingCart shoppingCart);
public Task<bool> Update(TbShoppingCart shoppingCart);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }