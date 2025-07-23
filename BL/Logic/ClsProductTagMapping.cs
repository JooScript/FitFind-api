using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsProductTagMapping : IProductTagMapping
    {
        ProductTagMappingData oProductTagMappingData;

        public ClsProductTagMapping(ECommerceContext context)
        {
            oProductTagMappingData = new ProductTagMappingData(context);
        }
               public async Task<TbProductTagMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var productTagMapping = await oProductTagMappingData.GetById(id);
                return productTagMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbProductTagMapping productTagMapping)
        {
              long productTagMappingId = -1;
            try
            {
                productTagMappingId = await oProductTagMappingData.Add(productTagMapping);
                return productTagMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbProductTagMapping productTagMapping)
        {
            try
            {
                return await oProductTagMappingData.Update(productTagMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbProductTagMapping productTagMapping) => productTagMapping.Id <= 0 ? await Add(productTagMapping) != -1 : await Update(productTagMapping);
        public async Task<List<TbProductTagMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oProductTagMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oProductTagMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oProductTagMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oProductTagMappingData.Delete(id);
        }

    }
}