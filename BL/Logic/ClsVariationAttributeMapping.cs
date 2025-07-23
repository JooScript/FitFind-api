using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsVariationAttributeMapping : IVariationAttributeMapping
    {
        VariationAttributeMappingData oVariationAttributeMappingData;

        public ClsVariationAttributeMapping(ECommerceContext context)
        {
            oVariationAttributeMappingData = new VariationAttributeMappingData(context);
        }
               public async Task<TbVariationAttributeMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var variationAttributeMapping = await oVariationAttributeMappingData.GetById(id);
                return variationAttributeMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbVariationAttributeMapping variationAttributeMapping)
        {
              long variationAttributeMappingId = -1;
            try
            {
                variationAttributeMappingId = await oVariationAttributeMappingData.Add(variationAttributeMapping);
                return variationAttributeMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbVariationAttributeMapping variationAttributeMapping)
        {
            try
            {
                return await oVariationAttributeMappingData.Update(variationAttributeMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbVariationAttributeMapping variationAttributeMapping) => variationAttributeMapping.Id <= 0 ? await Add(variationAttributeMapping) != -1 : await Update(variationAttributeMapping);
        public async Task<List<TbVariationAttributeMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oVariationAttributeMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oVariationAttributeMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oVariationAttributeMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oVariationAttributeMappingData.Delete(id);
        }

    }
}