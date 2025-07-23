using ECommerce.Models;
    public interface IShipment
    {
public Task<TbShipment> GetById(long id);
public Task<List<TbShipment>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbShipment shipment);
public Task<bool> Update(TbShipment shipment);
public Task<bool> Save(TbShipment shipment);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }