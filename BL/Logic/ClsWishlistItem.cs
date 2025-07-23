using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsWishlistItem : IWishlistItem
    {
        WishlistItemData oWishlistItemData;

        public ClsWishlistItem(ECommerceContext context)
        {
            oWishlistItemData = new WishlistItemData(context);
        }
               public async Task<TbWishlistItem> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var wishlistItem = await oWishlistItemData.GetById(id);
                return wishlistItem;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbWishlistItem wishlistItem)
        {
              long wishlistItemId = -1;
            try
            {
                wishlistItemId = await oWishlistItemData.Add(wishlistItem);
                return wishlistItemId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbWishlistItem wishlistItem)
        {
            try
            {
                return await oWishlistItemData.Update(wishlistItem);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbWishlistItem wishlistItem) => wishlistItem.Id <= 0 ? await Add(wishlistItem) != -1 : await Update(wishlistItem);
        public async Task<List<TbWishlistItem>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oWishlistItemData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oWishlistItemData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oWishlistItemData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oWishlistItemData.Delete(id);
        }

    }
}