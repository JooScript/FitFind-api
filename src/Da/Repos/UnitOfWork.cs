using ECommerce.Da.Context;
using ECommerce.Da.Contracts;
using ECommerce.Domains.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace ECommerce.Da.Repos;

public class UnitOfWork(ECommerceContext ctx, ILoggerFactory loggerFactory) : IUnitOfWork
{
    private readonly ConcurrentDictionary<Type, object> _repositories = new();
    private IDbContextTransaction? _tx;



    public ITableCmdRepo<Tb> Repository<Tb>() where Tb : BaseTable
    {
        return (ITableCmdRepo<Tb>)_repositories.GetOrAdd(typeof(Tb), _ => new TableCmdRepo<Tb>(ctx, loggerFactory.CreateLogger<TableCmdRepo<Tb>>(), new TableQryRepo<Tb>(ctx, loggerFactory.CreateLogger<TableQryRepo<Tb>>())));
    }

    public async Task BeginTransactionAsync() => _tx = await ctx.Database.BeginTransactionAsync();

    public async Task CommitAsync()
    {
        await ctx.SaveChangesAsync();
        if (_tx is not null) await _tx.CommitAsync();
    }

    public async Task RollbackAsync() => await _tx?.RollbackAsync()!;

    public Task<int> SaveChangesAsync() => ctx.SaveChangesAsync();

    public async ValueTask DisposeAsync()
    {
        if (_tx is not null) await _tx.DisposeAsync();
        await ctx.DisposeAsync();
    }


}
