using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsOrderReturn : IOrderReturn
    {
        OrderReturnData oOrderReturnData;

        public ClsOrderReturn(ECommerceContext context)
        {
            oOrderReturnData = new OrderReturnData(context);
        }
               public async Task<TbOrderReturn> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var orderReturn = await oOrderReturnData.GetById(id);
                return orderReturn;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbOrderReturn orderReturn)
        {
              long orderReturnId = -1;
            try
            {
                orderReturnId = await oOrderReturnData.Add(orderReturn);
                return orderReturnId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbOrderReturn orderReturn)
        {
            try
            {
                return await oOrderReturnData.Update(orderReturn);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbOrderReturn orderReturn) => orderReturn.Id <= 0 ? await Add(orderReturn) != -1 : await Update(orderReturn);
        public async Task<List<TbOrderReturn>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oOrderReturnData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oOrderReturnData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oOrderReturnData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oOrderReturnData.Delete(id);
        }

    }
}