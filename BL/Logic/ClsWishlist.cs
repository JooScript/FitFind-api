using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsWishlist : IWishlist
    {
        WishlistData oWishlistData;

        public ClsWishlist(ECommerceContext context)
        {
            oWishlistData = new WishlistData(context);
        }
               public async Task<TbWishlist> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var wishlist = await oWishlistData.GetById(id);
                return wishlist;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbWishlist wishlist)
        {
              long wishlistId = -1;
            try
            {
                wishlistId = await oWishlistData.Add(wishlist);
                return wishlistId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbWishlist wishlist)
        {
            try
            {
                return await oWishlistData.Update(wishlist);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbWishlist wishlist) => wishlist.Id <= 0 ? await Add(wishlist) != -1 : await Update(wishlist);
        public async Task<List<TbWishlist>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oWishlistData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oWishlistData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oWishlistData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oWishlistData.Delete(id);
        }

    }
}