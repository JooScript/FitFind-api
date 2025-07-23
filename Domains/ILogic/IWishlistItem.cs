using ECommerce.Models;
    public interface IWishlistItem
    {
public Task<TbWishlistItem> GetById(long id);
public Task<List<TbWishlistItem>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbWishlistItem wishlistItem);
public Task<bool> Update(TbWishlistItem wishlistItem);
public Task<bool> Save(TbWishlistItem wishlistItem);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }