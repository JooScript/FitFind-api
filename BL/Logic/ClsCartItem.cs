using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsCartItem : ICartItem
    {
        CartItemData oCartItemData;

        public ClsCartItem(ECommerceContext context)
        {
            oCartItemData = new CartItemData(context);
        }
               public async Task<TbCartItem> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var cartItem = await oCartItemData.GetById(id);
                return cartItem;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbCartItem cartItem)
        {
              long cartItemId = -1;
            try
            {
                cartItemId = await oCartItemData.Add(cartItem);
                return cartItemId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbCartItem cartItem)
        {
            try
            {
                return await oCartItemData.Update(cartItem);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbCartItem cartItem) => cartItem.Id <= 0 ? await Add(cartItem) != -1 : await Update(cartItem);
        public async Task<List<TbCartItem>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oCartItemData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oCartItemData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oCartItemData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oCartItemData.Delete(id);
        }

    }
}