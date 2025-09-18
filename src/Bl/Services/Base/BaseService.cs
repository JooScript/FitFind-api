using AutoMapper;
using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Contracts.Base;
using ECommerce.Bl.Contracts.Events;
using ECommerce.Bl.Events.Args;
using ECommerce.Da.Contracts;
using ECommerce.Domains.Base;
using System.Linq.Expressions;
using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Bl.Services.Base;

public abstract class BaseService<Tb, Dto> : IBaseService<Tb, Dto> where Tb : BaseTable
{
    readonly ITableRepoQry<Tb> _repoQuery;
    readonly ITableRepoCmd<Tb> _repoCommand;
    readonly IMapper _mapper;
    readonly IUserServiceQry _userServiceQuery;
    readonly IUnitOfWork _UnitOfWork;
    private readonly ICrudPublisher _publisher;

    public BaseService(ITableRepoQry<Tb> repoQuery, ITableRepoCmd<Tb> repoCommand, IMapper mapper, IUserServiceQry userServiceQuery, ICrudPublisher publisher)
    {
        _repoQuery = repoQuery;
        _repoCommand = repoCommand;
        _mapper = mapper;
        _userServiceQuery = userServiceQuery;
        _publisher = publisher;
    }

    public BaseService(IUnitOfWork unitofwork, IMapper mapper, IUserServiceQry userServiceQuery, ICrudPublisher publisher)
    {
        _UnitOfWork = unitofwork;
        _repoCommand = unitofwork.Repository<Tb>();
        _mapper = mapper;
        _userServiceQuery = userServiceQuery;
        _publisher = publisher;
    }

    public async Task<List<Dto>> GetAllAsync() => _mapper.Map<List<Tb>, List<Dto>>(await _repoQuery.GetAllAsync());

    public async Task<Dto> GetByIdAsync(Guid id) => _mapper.Map<Tb, Dto>(await _repoQuery.FindAsync(id));

    public async Task<(bool success, Guid id)> AddAsync(Dto entity, bool fireEvent = true)
    {
        var dbObject = _mapper.Map<Dto, Tb>(entity);
        var UserId = _userServiceQuery.GetLoggedInUserId();
        dbObject.CreatedBy = UserId;
        dbObject.CreatedAt = DateTime.Now;
        dbObject.CurrentState = 1;
        var result = await _repoCommand.AddAsync(dbObject);

        if (result.success && fireEvent)
        {
            _publisher.Publish(new EntityCreatedEventArgs(dbObject, UserId));
        }

        return (result.success, result.newId);
    }

    public async Task<bool> UpdateAsync(Dto entity, bool fireEvent = true)
    {
        var dbObject = _mapper.Map<Dto, Tb>(entity);
        var oldObj = dbObject;
        var userId = _userServiceQuery.GetLoggedInUserId();
        dbObject.UpdatedBy = userId;
        dbObject.UpdatedAt = DateTime.Now;

        var result = await _repoCommand.UpdateAsync(dbObject);

        if (result && fireEvent)
        {
            _publisher.Publish(new EntityUpdatedEventArgs(dbObject, userId, oldObj));
        }

        return result;
    }

    private async Task<bool> ChangeStatusAsync(Guid id, int status = 1, bool fireEvent = true)
    {
        var entity = await _repoQuery.FindAsync(id);

        if (entity == null) return false;

        var previousState = entity.CurrentState;

        entity.CurrentState = status;
        var userId = _userServiceQuery.GetLoggedInUserId();
        entity.UpdatedBy = userId;

        var success = await _repoCommand.UpdateAsync(entity);

        if (success && fireEvent)
        {
            _publisher.Publish(new EntityStatusChangedEventArgs(entity, userId, previousState, status));
        }
        return success;
    }

    public async Task<bool> ActivateAsync(Guid id, bool fireEvent = true) => await ChangeStatusAsync(id, (int)enCurrentState.Active, fireEvent);

    public async Task<bool> DeactivateAsync(Guid id, bool fireEvent = true) => await ChangeStatusAsync(id, (int)enCurrentState.InActive, fireEvent);

    public async Task<bool> DeleteAsync(Guid id, bool fireEvent = true) => await ChangeStatusAsync(id, (int)enCurrentState.Deleted, fireEvent);

    public async Task<int> CountAsync(CancellationToken cancellationToken) => await _repoQuery.CountAsync(e => e.CurrentState > 0, cancellationToken);

    public async Task<bool> IsExistsAsync(Expression<Func<Tb, bool>> filter, CancellationToken cancellationToken) => await _repoQuery.IsExistsAsync(filter, cancellationToken);

    public async Task<bool> IsExistsAsync(Guid Id, CancellationToken cancellationToken) => await _repoQuery.IsExistsAsync(Id, cancellationToken);

}