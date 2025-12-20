using ECommerce.Domains.Base;

namespace ECommerce.Da.Contracts;

public interface ITableCmdRepo<Tb> where Tb : BaseTable
{
    Task<(bool success, Guid newId)> AddAsync(Tb entity, CancellationToken cancellationToken = default);

    Task<(bool success, IEnumerable<Guid> newIds)> AddAsync(IEnumerable<Tb> entities, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Tb entity, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(IEnumerable<Tb> entities, CancellationToken cancellationToken = default);

    Task<bool> ChangeStatusAsync(Guid id, Guid userId, int status = 1, CancellationToken cancellationToken = default);

    Task<bool> ChangeStatusAsync(IEnumerable<Guid> id, Guid userId, int status = 1, CancellationToken cancellationToken = default);

}