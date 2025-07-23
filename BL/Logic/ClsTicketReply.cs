using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsTicketReply : ITicketReply
    {
        TicketReplyData oTicketReplyData;

        public ClsTicketReply(ECommerceContext context)
        {
            oTicketReplyData = new TicketReplyData(context);
        }
               public async Task<TbTicketReply> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var ticketReply = await oTicketReplyData.GetById(id);
                return ticketReply;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbTicketReply ticketReply)
        {
              long ticketReplyId = -1;
            try
            {
                ticketReplyId = await oTicketReplyData.Add(ticketReply);
                return ticketReplyId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbTicketReply ticketReply)
        {
            try
            {
                return await oTicketReplyData.Update(ticketReply);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbTicketReply ticketReply) => ticketReply.Id <= 0 ? await Add(ticketReply) != -1 : await Update(ticketReply);
        public async Task<List<TbTicketReply>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oTicketReplyData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oTicketReplyData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oTicketReplyData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oTicketReplyData.Delete(id);
        }

    }
}