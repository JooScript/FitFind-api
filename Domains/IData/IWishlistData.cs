using ECommerce.Models;
    public interface IWishlistData
    {
public Task<TbWishlist> GetById(long id);
public Task<List<TbWishlist>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbWishlist wishlist);
public Task<bool> Update(TbWishlist wishlist);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }