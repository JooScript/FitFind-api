using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsOrderStatusHistory : IOrderStatusHistory
    {
        OrderStatusHistoryData oOrderStatusHistoryData;

        public ClsOrderStatusHistory(ECommerceContext context)
        {
            oOrderStatusHistoryData = new OrderStatusHistoryData(context);
        }
               public async Task<TbOrderStatusHistory> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var orderStatusHistory = await oOrderStatusHistoryData.GetById(id);
                return orderStatusHistory;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbOrderStatusHistory orderStatusHistory)
        {
              long orderStatusHistoryId = -1;
            try
            {
                orderStatusHistoryId = await oOrderStatusHistoryData.Add(orderStatusHistory);
                return orderStatusHistoryId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbOrderStatusHistory orderStatusHistory)
        {
            try
            {
                return await oOrderStatusHistoryData.Update(orderStatusHistory);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbOrderStatusHistory orderStatusHistory) => orderStatusHistory.Id <= 0 ? await Add(orderStatusHistory) != -1 : await Update(orderStatusHistory);
        public async Task<List<TbOrderStatusHistory>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oOrderStatusHistoryData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oOrderStatusHistoryData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oOrderStatusHistoryData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oOrderStatusHistoryData.Delete(id);
        }

    }
}