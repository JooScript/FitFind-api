using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsTag : ITag
    {
        TagData oTagData;

        public ClsTag(ECommerceContext context)
        {
            oTagData = new TagData(context);
        }
               public async Task<TbTag> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var tag = await oTagData.GetById(id);
                return tag;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbTag tag)
        {
              long tagId = -1;
            try
            {
                tagId = await oTagData.Add(tag);
                return tagId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbTag tag)
        {
            try
            {
                return await oTagData.Update(tag);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbTag tag) => tag.Id <= 0 ? await Add(tag) != -1 : await Update(tag);
        public async Task<List<TbTag>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oTagData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oTagData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oTagData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oTagData.Delete(id);
        }

    }
}