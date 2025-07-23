using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsOrder : IOrder
    {
        OrderData oOrderData;

        public ClsOrder(ECommerceContext context)
        {
            oOrderData = new OrderData(context);
        }
               public async Task<TbOrder> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var order = await oOrderData.GetById(id);
                return order;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbOrder order)
        {
              long orderId = -1;
            try
            {
                orderId = await oOrderData.Add(order);
                return orderId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbOrder order)
        {
            try
            {
                return await oOrderData.Update(order);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbOrder order) => order.Id <= 0 ? await Add(order) != -1 : await Update(order);
        public async Task<List<TbOrder>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oOrderData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oOrderData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oOrderData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oOrderData.Delete(id);
        }

    }
}