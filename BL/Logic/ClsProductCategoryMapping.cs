using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsProductCategoryMapping : IProductCategoryMapping
    {
        ProductCategoryMappingData oProductCategoryMappingData;

        public ClsProductCategoryMapping(ECommerceContext context)
        {
            oProductCategoryMappingData = new ProductCategoryMappingData(context);
        }
               public async Task<TbProductCategoryMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var productCategoryMapping = await oProductCategoryMappingData.GetById(id);
                return productCategoryMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbProductCategoryMapping productCategoryMapping)
        {
              long productCategoryMappingId = -1;
            try
            {
                productCategoryMappingId = await oProductCategoryMappingData.Add(productCategoryMapping);
                return productCategoryMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbProductCategoryMapping productCategoryMapping)
        {
            try
            {
                return await oProductCategoryMappingData.Update(productCategoryMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbProductCategoryMapping productCategoryMapping) => productCategoryMapping.Id <= 0 ? await Add(productCategoryMapping) != -1 : await Update(productCategoryMapping);
        public async Task<List<TbProductCategoryMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oProductCategoryMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oProductCategoryMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oProductCategoryMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oProductCategoryMappingData.Delete(id);
        }

    }
}