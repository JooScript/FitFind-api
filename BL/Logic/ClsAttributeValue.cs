using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsAttributeValue : IAttributeValue
    {
        AttributeValueData oAttributeValueData;

        public ClsAttributeValue(ECommerceContext context)
        {
            oAttributeValueData = new AttributeValueData(context);
        }
               public async Task<TbAttributeValue> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var attributeValue = await oAttributeValueData.GetById(id);
                return attributeValue;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbAttributeValue attributeValue)
        {
              long attributeValueId = -1;
            try
            {
                attributeValueId = await oAttributeValueData.Add(attributeValue);
                return attributeValueId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbAttributeValue attributeValue)
        {
            try
            {
                return await oAttributeValueData.Update(attributeValue);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbAttributeValue attributeValue) => attributeValue.Id <= 0 ? await Add(attributeValue) != -1 : await Update(attributeValue);
        public async Task<List<TbAttributeValue>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oAttributeValueData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oAttributeValueData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oAttributeValueData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oAttributeValueData.Delete(id);
        }

    }
}