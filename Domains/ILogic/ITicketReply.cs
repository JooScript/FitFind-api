using ECommerce.Models;
    public interface ITicketReply
    {
public Task<TbTicketReply> GetById(long id);
public Task<List<TbTicketReply>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbTicketReply ticketReply);
public Task<bool> Update(TbTicketReply ticketReply);
public Task<bool> Save(TbTicketReply ticketReply);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }