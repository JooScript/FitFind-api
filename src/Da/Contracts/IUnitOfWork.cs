using ECommerce.Domains.Base;

namespace ECommerce.Da.Contracts;

public interface IUnitOfWork : IAsyncDisposable
{
    ITableRepoCmd<Tb> Repository<Tb>() where Tb : BaseTable;
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task<int> SaveChangesAsync();
}
