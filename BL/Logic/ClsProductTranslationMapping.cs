using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsProductTranslationMapping : IProductTranslationMapping
    {
        ProductTranslationMappingData oProductTranslationMappingData;

        public ClsProductTranslationMapping(ECommerceContext context)
        {
            oProductTranslationMappingData = new ProductTranslationMappingData(context);
        }
               public async Task<TbProductTranslationMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var productTranslationMapping = await oProductTranslationMappingData.GetById(id);
                return productTranslationMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbProductTranslationMapping productTranslationMapping)
        {
              long productTranslationMappingId = -1;
            try
            {
                productTranslationMappingId = await oProductTranslationMappingData.Add(productTranslationMapping);
                return productTranslationMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbProductTranslationMapping productTranslationMapping)
        {
            try
            {
                return await oProductTranslationMappingData.Update(productTranslationMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbProductTranslationMapping productTranslationMapping) => productTranslationMapping.Id <= 0 ? await Add(productTranslationMapping) != -1 : await Update(productTranslationMapping);
        public async Task<List<TbProductTranslationMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oProductTranslationMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oProductTranslationMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oProductTranslationMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oProductTranslationMappingData.Delete(id);
        }

    }
}