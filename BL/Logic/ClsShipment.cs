using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsShipment : IShipment
    {
        ShipmentData oShipmentData;

        public ClsShipment(ECommerceContext context)
        {
            oShipmentData = new ShipmentData(context);
        }
               public async Task<TbShipment> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var shipment = await oShipmentData.GetById(id);
                return shipment;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbShipment shipment)
        {
              long shipmentId = -1;
            try
            {
                shipmentId = await oShipmentData.Add(shipment);
                return shipmentId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbShipment shipment)
        {
            try
            {
                return await oShipmentData.Update(shipment);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbShipment shipment) => shipment.Id <= 0 ? await Add(shipment) != -1 : await Update(shipment);
        public async Task<List<TbShipment>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oShipmentData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oShipmentData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oShipmentData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oShipmentData.Delete(id);
        }

    }
}