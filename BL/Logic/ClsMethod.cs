using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsMethod : IMethod
    {
        MethodData oMethodData;

        public ClsMethod(ECommerceContext context)
        {
            oMethodData = new MethodData(context);
        }
               public async Task<TbMethod> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var method = await oMethodData.GetById(id);
                return method;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbMethod method)
        {
              long methodId = -1;
            try
            {
                methodId = await oMethodData.Add(method);
                return methodId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbMethod method)
        {
            try
            {
                return await oMethodData.Update(method);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbMethod method) => method.Id <= 0 ? await Add(method) != -1 : await Update(method);
        public async Task<List<TbMethod>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oMethodData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oMethodData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oMethodData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oMethodData.Delete(id);
        }

    }
}