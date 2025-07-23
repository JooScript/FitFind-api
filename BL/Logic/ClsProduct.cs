using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsProduct : IProduct
    {
        ProductData oProductData;

        public ClsProduct(ECommerceContext context)
        {
            oProductData = new ProductData(context);
        }
               public async Task<TbProduct> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var product = await oProductData.GetById(id);
                return product;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbProduct product)
        {
              long productId = -1;
            try
            {
                productId = await oProductData.Add(product);
                return productId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbProduct product)
        {
            try
            {
                return await oProductData.Update(product);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbProduct product) => product.Id <= 0 ? await Add(product) != -1 : await Update(product);
        public async Task<List<TbProduct>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oProductData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oProductData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oProductData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oProductData.Delete(id);
        }

    }
}