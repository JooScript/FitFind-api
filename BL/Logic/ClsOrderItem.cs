using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsOrderItem : IOrderItem
    {
        OrderItemData oOrderItemData;

        public ClsOrderItem(ECommerceContext context)
        {
            oOrderItemData = new OrderItemData(context);
        }
               public async Task<TbOrderItem> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var orderItem = await oOrderItemData.GetById(id);
                return orderItem;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbOrderItem orderItem)
        {
              long orderItemId = -1;
            try
            {
                orderItemId = await oOrderItemData.Add(orderItem);
                return orderItemId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbOrderItem orderItem)
        {
            try
            {
                return await oOrderItemData.Update(orderItem);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbOrderItem orderItem) => orderItem.Id <= 0 ? await Add(orderItem) != -1 : await Update(orderItem);
        public async Task<List<TbOrderItem>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oOrderItemData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oOrderItemData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oOrderItemData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oOrderItemData.Delete(id);
        }

    }
}