using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsSupportTicket : ISupportTicket
    {
        SupportTicketData oSupportTicketData;

        public ClsSupportTicket(ECommerceContext context)
        {
            oSupportTicketData = new SupportTicketData(context);
        }
               public async Task<TbSupportTicket> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var supportTicket = await oSupportTicketData.GetById(id);
                return supportTicket;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbSupportTicket supportTicket)
        {
              long supportTicketId = -1;
            try
            {
                supportTicketId = await oSupportTicketData.Add(supportTicket);
                return supportTicketId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbSupportTicket supportTicket)
        {
            try
            {
                return await oSupportTicketData.Update(supportTicket);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbSupportTicket supportTicket) => supportTicket.Id <= 0 ? await Add(supportTicket) != -1 : await Update(supportTicket);
        public async Task<List<TbSupportTicket>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oSupportTicketData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oSupportTicketData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oSupportTicketData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oSupportTicketData.Delete(id);
        }

    }
}