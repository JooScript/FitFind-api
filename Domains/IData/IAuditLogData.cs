using ECommerce.Models;
    public interface IAuditLogData
    {
public Task<TbAuditLog> GetById(long id);
public Task<List<TbAuditLog>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbAuditLog auditLog);
public Task<bool> Update(TbAuditLog auditLog);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }