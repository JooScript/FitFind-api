using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsAttribute : IAttribute
    {
        AttributeData oAttributeData;

        public ClsAttribute(ECommerceContext context)
        {
            oAttributeData = new AttributeData(context);
        }
               public async Task<TbAttribute> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var attribute = await oAttributeData.GetById(id);
                return attribute;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbAttribute attribute)
        {
              long attributeId = -1;
            try
            {
                attributeId = await oAttributeData.Add(attribute);
                return attributeId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbAttribute attribute)
        {
            try
            {
                return await oAttributeData.Update(attribute);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbAttribute attribute) => attribute.Id <= 0 ? await Add(attribute) != -1 : await Update(attribute);
        public async Task<List<TbAttribute>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oAttributeData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oAttributeData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oAttributeData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oAttributeData.Delete(id);
        }

    }
}