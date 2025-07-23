using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsDiscountCategoryMapping : IDiscountCategoryMapping
    {
        DiscountCategoryMappingData oDiscountCategoryMappingData;

        public ClsDiscountCategoryMapping(ECommerceContext context)
        {
            oDiscountCategoryMappingData = new DiscountCategoryMappingData(context);
        }
               public async Task<TbDiscountCategoryMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var discountCategoryMapping = await oDiscountCategoryMappingData.GetById(id);
                return discountCategoryMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbDiscountCategoryMapping discountCategoryMapping)
        {
              long discountCategoryMappingId = -1;
            try
            {
                discountCategoryMappingId = await oDiscountCategoryMappingData.Add(discountCategoryMapping);
                return discountCategoryMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbDiscountCategoryMapping discountCategoryMapping)
        {
            try
            {
                return await oDiscountCategoryMappingData.Update(discountCategoryMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbDiscountCategoryMapping discountCategoryMapping) => discountCategoryMapping.Id <= 0 ? await Add(discountCategoryMapping) != -1 : await Update(discountCategoryMapping);
        public async Task<List<TbDiscountCategoryMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oDiscountCategoryMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oDiscountCategoryMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oDiscountCategoryMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oDiscountCategoryMappingData.Delete(id);
        }

    }
}