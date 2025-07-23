using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsDiscountProductMapping : IDiscountProductMapping
    {
        DiscountProductMappingData oDiscountProductMappingData;

        public ClsDiscountProductMapping(ECommerceContext context)
        {
            oDiscountProductMappingData = new DiscountProductMappingData(context);
        }
               public async Task<TbDiscountProductMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var discountProductMapping = await oDiscountProductMappingData.GetById(id);
                return discountProductMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbDiscountProductMapping discountProductMapping)
        {
              long discountProductMappingId = -1;
            try
            {
                discountProductMappingId = await oDiscountProductMappingData.Add(discountProductMapping);
                return discountProductMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbDiscountProductMapping discountProductMapping)
        {
            try
            {
                return await oDiscountProductMappingData.Update(discountProductMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbDiscountProductMapping discountProductMapping) => discountProductMapping.Id <= 0 ? await Add(discountProductMapping) != -1 : await Update(discountProductMapping);
        public async Task<List<TbDiscountProductMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oDiscountProductMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oDiscountProductMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oDiscountProductMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oDiscountProductMappingData.Delete(id);
        }

    }
}