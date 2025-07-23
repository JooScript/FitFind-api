using ECommerce.Models;
    public interface IInventoryTransactionData
    {
public Task<TbInventoryTransaction> GetById(long id);
public Task<List<TbInventoryTransaction>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbInventoryTransaction inventoryTransaction);
public Task<bool> Update(TbInventoryTransaction inventoryTransaction);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }