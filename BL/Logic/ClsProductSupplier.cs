using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsProductSupplier : IProductSupplier
    {
        ProductSupplierData oProductSupplierData;

        public ClsProductSupplier(ECommerceContext context)
        {
            oProductSupplierData = new ProductSupplierData(context);
        }
               public async Task<TbProductSupplier> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var productSupplier = await oProductSupplierData.GetById(id);
                return productSupplier;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbProductSupplier productSupplier)
        {
              long productSupplierId = -1;
            try
            {
                productSupplierId = await oProductSupplierData.Add(productSupplier);
                return productSupplierId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbProductSupplier productSupplier)
        {
            try
            {
                return await oProductSupplierData.Update(productSupplier);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbProductSupplier productSupplier) => productSupplier.Id <= 0 ? await Add(productSupplier) != -1 : await Update(productSupplier);
        public async Task<List<TbProductSupplier>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oProductSupplierData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oProductSupplierData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oProductSupplierData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oProductSupplierData.Delete(id);
        }

    }
}