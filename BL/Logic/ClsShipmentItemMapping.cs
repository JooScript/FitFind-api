using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsShipmentItemMapping : IShipmentItemMapping
    {
        ShipmentItemMappingData oShipmentItemMappingData;

        public ClsShipmentItemMapping(ECommerceContext context)
        {
            oShipmentItemMappingData = new ShipmentItemMappingData(context);
        }
               public async Task<TbShipmentItemMapping> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var shipmentItemMapping = await oShipmentItemMappingData.GetById(id);
                return shipmentItemMapping;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbShipmentItemMapping shipmentItemMapping)
        {
              long shipmentItemMappingId = -1;
            try
            {
                shipmentItemMappingId = await oShipmentItemMappingData.Add(shipmentItemMapping);
                return shipmentItemMappingId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbShipmentItemMapping shipmentItemMapping)
        {
            try
            {
                return await oShipmentItemMappingData.Update(shipmentItemMapping);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbShipmentItemMapping shipmentItemMapping) => shipmentItemMapping.Id <= 0 ? await Add(shipmentItemMapping) != -1 : await Update(shipmentItemMapping);
        public async Task<List<TbShipmentItemMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oShipmentItemMappingData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oShipmentItemMappingData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oShipmentItemMappingData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oShipmentItemMappingData.Delete(id);
        }

    }
}