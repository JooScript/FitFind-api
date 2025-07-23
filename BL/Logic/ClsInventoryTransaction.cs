using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsInventoryTransaction : IInventoryTransaction
    {
        InventoryTransactionData oInventoryTransactionData;

        public ClsInventoryTransaction(ECommerceContext context)
        {
            oInventoryTransactionData = new InventoryTransactionData(context);
        }
               public async Task<TbInventoryTransaction> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var inventoryTransaction = await oInventoryTransactionData.GetById(id);
                return inventoryTransaction;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbInventoryTransaction inventoryTransaction)
        {
              long inventoryTransactionId = -1;
            try
            {
                inventoryTransactionId = await oInventoryTransactionData.Add(inventoryTransaction);
                return inventoryTransactionId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbInventoryTransaction inventoryTransaction)
        {
            try
            {
                return await oInventoryTransactionData.Update(inventoryTransaction);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbInventoryTransaction inventoryTransaction) => inventoryTransaction.Id <= 0 ? await Add(inventoryTransaction) != -1 : await Update(inventoryTransaction);
        public async Task<List<TbInventoryTransaction>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oInventoryTransactionData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oInventoryTransactionData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oInventoryTransactionData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oInventoryTransactionData.Delete(id);
        }

    }
}