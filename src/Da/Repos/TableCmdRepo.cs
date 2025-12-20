using ECommerce.Da.Context;
using ECommerce.Da.Contracts;
using ECommerce.Da.Exceptions;
using ECommerce.Domains.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Da.Repos;

public class TableCmdRepo<Tb>(ECommerceContext context, ILogger<TableCmdRepo<Tb>> logger, ITableQryRepo<Tb> repoQuery) : ITableCmdRepo<Tb> where Tb : BaseTable
{
    private readonly DbSet<Tb> _dbSet = (context ?? throw new ArgumentNullException(nameof(context))).Set<Tb>();

    public async Task<(bool success, Guid newId)> AddAsync(Tb entity, CancellationToken cancellationToken = default)
    {
        const string methodName = nameof(AddAsync);

        if (entity == null)
        {
            logger.LogWarning(methodName, "Entity cannot be null");
            throw new ArgumentNullException(nameof(entity));
        }

        try
        {
            entity.Id = Guid.Empty;
            entity.CreatedAt = DateTime.UtcNow;
            await _dbSet.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return (true, entity.Id);
        }
        catch (Exception ex)
        {
            throw new DataAccessException(logger, ex, $"Failed to add entity of type {typeof(Tb).Name}");
        }
    }

    public async Task<(bool success, IEnumerable<Guid> newIds)> AddAsync(IEnumerable<Tb> entities, CancellationToken cancellationToken = default)
    {
        const string methodName = nameof(AddAsync);

        if (entities == null)
        {
            logger.LogWarning(methodName, "Entities collection cannot be null");
            throw new ArgumentNullException(nameof(entities));
        }

        if (!entities.Any())
        {
            return (true, Enumerable.Empty<Guid>());
        }

        try
        {
            var utcNow = DateTime.UtcNow;
            var entityList = entities.ToList();

            foreach (var entity in entityList)
            {
                entity.Id = Guid.Empty;
                entity.CreatedAt = utcNow;
            }

            await _dbSet.AddRangeAsync(entityList, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return (true, entityList.Select(e => e.Id));
        }
        catch (Exception ex)
        {
            throw new DataAccessException(logger, ex, $"Failed to add entities of type {typeof(Tb).Name}");
        }
    }

    public async Task<bool> UpdateAsync(Tb entity, CancellationToken cancellationToken = default)
    {
        const string methodName = nameof(UpdateAsync);

        if (entity == null)
        {
            logger.LogWarning(methodName, "Entity cannot be null");
            throw new ArgumentNullException(nameof(entity));
        }

        try
        {
            var dbData = await repoQuery.FindAsync(entity.Id, cancellationToken);
            if (dbData == null)
            {
                logger.LogWarning(methodName, entity.Id);
                return false;
            }

            entity.CreatedAt = dbData.CreatedAt;
            entity.CreatedBy = dbData.CreatedBy;
            entity.UpdatedAt = DateTime.UtcNow;

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            logger.LogWarning(methodName, $"Concurrency conflict updating entity {entity.Id}");
            throw new DataAccessException(logger, ex, $"Concurrency conflict updating entity {entity.Id}", isConcurrencyConflict: true);
        }
        catch (Exception ex)
        {
            throw new DataAccessException(logger, ex, $"Failed to update entity {entity.Id} of type {typeof(Tb).Name}");
        }
    }

    public async Task<bool> UpdateAsync(IEnumerable<Tb> entities, CancellationToken cancellationToken = default)
    {
        const string methodName = nameof(UpdateAsync);

        if (entities == null)
        {
            logger.LogWarning(methodName, "Entities collection cannot be null");
            throw new ArgumentNullException(nameof(entities));
        }

        if (!entities.Any())
        {
            return true;
        }

        try
        {
            var entityList = entities.ToList();
            var ids = entityList.Select(e => e.Id).ToList();
            var utcNow = DateTime.UtcNow;

            // Get all existing entities in one query
            var existingEntities = await repoQuery.FindAsync(ids, cancellationToken);
            var existingEntitiesDict = existingEntities.ToDictionary(e => e.Id);

            // Check if all entities exist
            foreach (var entity in entityList)
            {
                if (!existingEntitiesDict.TryGetValue(entity.Id, out var dbData))
                {
                    logger.LogInformation(methodName, entity.Id);
                    return false;
                }


                entity.CreatedAt = dbData.CreatedAt;
                entity.CreatedBy = dbData.CreatedBy;
                entity.UpdatedAt = utcNow;


                context.Entry(entity).State = EntityState.Modified;
            }

            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            logger.LogWarning(methodName, $"Concurrency conflict updating entities");
            throw new DataAccessException(logger, ex, "Concurrency conflict updating entities", isConcurrencyConflict: true);
        }
        catch (Exception ex)
        {
            throw new DataAccessException(logger, ex, $"Failed to update entities of type {typeof(Tb).Name}");
        }
    }

    public async Task<bool> ChangeStatusAsync(Guid id, Guid userId, int status, CancellationToken cancellationToken = default)
    {
        const string methodName = nameof(ChangeStatusAsync);

        try
        {
            var entity = await repoQuery.FindAsync(id, cancellationToken);
            if (entity == null)
            {
                logger.LogInformation(methodName, id);
                return false;
            }

            entity.CurrentState = status;
            entity.UpdatedBy = userId;
            entity.UpdatedAt = DateTime.UtcNow;

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch (Exception ex)
        {
            throw new DataAccessException(logger, ex, $"Failed to change status for entity {id} of type {typeof(Tb).Name}");
        }
    }

    public async Task<bool> ChangeStatusAsync(IEnumerable<Guid> ids, Guid userId, int status = 1, CancellationToken cancellationToken = default)
    {
        const string methodName = nameof(ChangeStatusAsync);

        if (ids == null)
        {
            logger.LogWarning(methodName, "Ids collection cannot be null");
            throw new ArgumentNullException(nameof(ids));
        }

        if (!ids.Any())
        {
            return true; // Consider empty collection as successful
        }

        try
        {
            var distinctIds = ids.Distinct().ToList();
            var entities = await _dbSet
                .Where(e => distinctIds.Contains(e.Id))
                .ToListAsync(cancellationToken);

            // Check if all entities were found
            if (entities.Count != distinctIds.Count)
            {
                var foundIds = entities.Select(e => e.Id).ToList();
                var missingIds = distinctIds.Except(foundIds).ToList();

                logger.LogWarning(methodName, $"Some entities not found: {string.Join(", ", missingIds)}");
                return false;
            }

            var utcNow = DateTime.UtcNow;
            foreach (var entity in entities)
            {
                entity.CurrentState = status;
                entity.UpdatedBy = userId;
                entity.UpdatedAt = utcNow;
                context.Entry(entity).State = EntityState.Modified;
            }

            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            throw new DataAccessException(logger, ex,
                $"Failed to change status for multiple entities of type {typeof(Tb).Name}");
        }
    }

}