using ECommerce.Models;
    public interface IShipmentItemMappingData
    {
public Task<TbShipmentItemMapping> GetById(long id);
public Task<List<TbShipmentItemMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbShipmentItemMapping shipmentItemMapping);
public Task<bool> Update(TbShipmentItemMapping shipmentItemMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }