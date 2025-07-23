using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsVariation : IVariation
    {
        VariationData oVariationData;

        public ClsVariation(ECommerceContext context)
        {
            oVariationData = new VariationData(context);
        }
               public async Task<TbVariation> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var variation = await oVariationData.GetById(id);
                return variation;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbVariation variation)
        {
              long variationId = -1;
            try
            {
                variationId = await oVariationData.Add(variation);
                return variationId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbVariation variation)
        {
            try
            {
                return await oVariationData.Update(variation);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbVariation variation) => variation.Id <= 0 ? await Add(variation) != -1 : await Update(variation);
        public async Task<List<TbVariation>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oVariationData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oVariationData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oVariationData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oVariationData.Delete(id);
        }

    }
}