using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsTaxRate : ITaxRate
    {
        TaxRateData oTaxRateData;

        public ClsTaxRate(ECommerceContext context)
        {
            oTaxRateData = new TaxRateData(context);
        }
               public async Task<TbTaxRate> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var taxRate = await oTaxRateData.GetById(id);
                return taxRate;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbTaxRate taxRate)
        {
              long taxRateId = -1;
            try
            {
                taxRateId = await oTaxRateData.Add(taxRate);
                return taxRateId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbTaxRate taxRate)
        {
            try
            {
                return await oTaxRateData.Update(taxRate);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbTaxRate taxRate) => taxRate.Id <= 0 ? await Add(taxRate) != -1 : await Update(taxRate);
        public async Task<List<TbTaxRate>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oTaxRateData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oTaxRateData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oTaxRateData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oTaxRateData.Delete(id);
        }

    }
}