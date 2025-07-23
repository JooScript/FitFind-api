using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsShoppingCart : IShoppingCart
    {
        ShoppingCartData oShoppingCartData;

        public ClsShoppingCart(ECommerceContext context)
        {
            oShoppingCartData = new ShoppingCartData(context);
        }
               public async Task<TbShoppingCart> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var shoppingCart = await oShoppingCartData.GetById(id);
                return shoppingCart;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbShoppingCart shoppingCart)
        {
              long shoppingCartId = -1;
            try
            {
                shoppingCartId = await oShoppingCartData.Add(shoppingCart);
                return shoppingCartId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbShoppingCart shoppingCart)
        {
            try
            {
                return await oShoppingCartData.Update(shoppingCart);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbShoppingCart shoppingCart) => shoppingCart.Id <= 0 ? await Add(shoppingCart) != -1 : await Update(shoppingCart);
        public async Task<List<TbShoppingCart>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oShoppingCartData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oShoppingCartData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oShoppingCartData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oShoppingCartData.Delete(id);
        }

    }
}