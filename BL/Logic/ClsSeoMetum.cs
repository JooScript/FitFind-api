using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsSeoMetum : ISeoMetum
    {
        SeoMetumData oSeoMetumData;

        public ClsSeoMetum(ECommerceContext context)
        {
            oSeoMetumData = new SeoMetumData(context);
        }
               public async Task<TbSeoMetum> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var seoMetum = await oSeoMetumData.GetById(id);
                return seoMetum;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbSeoMetum seoMetum)
        {
              long seoMetumId = -1;
            try
            {
                seoMetumId = await oSeoMetumData.Add(seoMetum);
                return seoMetumId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbSeoMetum seoMetum)
        {
            try
            {
                return await oSeoMetumData.Update(seoMetum);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbSeoMetum seoMetum) => seoMetum.Id <= 0 ? await Add(seoMetum) != -1 : await Update(seoMetum);
        public async Task<List<TbSeoMetum>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oSeoMetumData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oSeoMetumData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oSeoMetumData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oSeoMetumData.Delete(id);
        }

    }
}