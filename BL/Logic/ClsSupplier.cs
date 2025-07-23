using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsSupplier : ISupplier
    {
        SupplierData oSupplierData;

        public ClsSupplier(ECommerceContext context)
        {
            oSupplierData = new SupplierData(context);
        }
               public async Task<TbSupplier> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var supplier = await oSupplierData.GetById(id);
                return supplier;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbSupplier supplier)
        {
              long supplierId = -1;
            try
            {
                supplierId = await oSupplierData.Add(supplier);
                return supplierId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbSupplier supplier)
        {
            try
            {
                return await oSupplierData.Update(supplier);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbSupplier supplier) => supplier.Id <= 0 ? await Add(supplier) != -1 : await Update(supplier);
        public async Task<List<TbSupplier>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oSupplierData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oSupplierData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oSupplierData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oSupplierData.Delete(id);
        }

    }
}