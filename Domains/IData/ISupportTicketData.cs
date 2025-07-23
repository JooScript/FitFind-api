using ECommerce.Models;
    public interface ISupportTicketData
    {
public Task<TbSupportTicket> GetById(long id);
public Task<List<TbSupportTicket>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbSupportTicket supportTicket);
public Task<bool> Update(TbSupportTicket supportTicket);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }