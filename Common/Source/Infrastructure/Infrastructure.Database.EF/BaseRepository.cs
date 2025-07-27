using System.Linq.Expressions;
using Common.Application.Contracts.Interfaces;
using Common.Application.Contracts.User;
using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Common.Shared.Providers;
using Microsoft.EntityFrameworkCore;
using MoreLinq;

namespace Common.Infrastructure.Database.EF;

public abstract class BaseRepository<TAggregateRoot> : IRepository<TAggregateRoot>
    where TAggregateRoot : BaseAggregateRoot
{
    private readonly BaseDbContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly DbSet<TAggregateRoot> _aggregateRootContext;
    private readonly IQueryable<TAggregateRoot> _aggregateRootQuery;
    private readonly IUserContextProvider _userContextProvider;

    protected BaseRepository(
        BaseDbContext context,
        IDateTimeProvider dateTimeProvider,
        IUserContextProvider userContextProvider,
        Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? query = null)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
        _userContextProvider = userContextProvider;
        _aggregateRootContext = _context.Set<TAggregateRoot>();
        _aggregateRootQuery = query?.Invoke(_aggregateRootContext) ?? _aggregateRootContext;
    }

    public async Task<TAggregateRoot?> GetAsync(AggregateId id, CancellationToken cancellationToken) =>
        await GetAsync(root => root.Id == id, cancellationToken);

    public async Task<TAggregateRoot?> GetAsync(
        Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken)
    {
        var aggregateRoot = GetFromLocal(condition.Compile()) ??
                            await _aggregateRootQuery.FirstOrDefaultAsync(condition, cancellationToken);

        TrySetAggregateRoot(aggregateRoot);
        return aggregateRoot;
    }

    public async Task<IReadOnlyDictionary<AggregateId, TAggregateRoot>> GetManyAsync(
        IReadOnlyCollection<AggregateId> ids, CancellationToken cancellationToken)
    {
        var uniqueIds = ids.ToHashSet();
        var aggregateRoots = GetManyFromLocal(a => uniqueIds.Contains(a.Id));

        var missingIds = uniqueIds.Except(aggregateRoots.Select(a => a.Id)).ToHashSet();
        if (missingIds.Any())
            aggregateRoots.AddRange(await _aggregateRootContext.Where(a => missingIds.Contains(a.Id))
                .ToListAsync(cancellationToken));

        foreach (var aggregateRoot in aggregateRoots)
            SetDependencies(aggregateRoot);

        return aggregateRoots.ToDictionary(k => k.Id);
    }

    public async Task<IReadOnlyDictionary<AggregateId, TAggregateRoot>> GetManyAsync(
        Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken)
    {
        var aggregateRootsFromLocal = GetManyFromLocal(condition.Compile());
        var aggregateRootIdsFromLocal = aggregateRootsFromLocal.Select(a => a.Id).ToList();

        var combinedCondition = condition.And(root => !aggregateRootIdsFromLocal.Contains(root.Id));

        var aggregateRootsFromDb = await _aggregateRootContext.Where(combinedCondition).ToListAsync(cancellationToken);
        var aggregateRoots = aggregateRootsFromLocal.Concat(aggregateRootsFromDb).ToList();

        foreach (var aggregateRoot in aggregateRoots)
            SetDependencies(aggregateRoot);

        return aggregateRoots.ToDictionary(k => k.Id);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken)
    {
        if (ExistsLocal(condition.Compile()))
            return true;

        return await _aggregateRootQuery.AnyAsync(condition, cancellationToken);
    }

    public async Task<IReadOnlyDictionary<AggregateId, bool>> ExistsAsync(
        IReadOnlyCollection<AggregateId> ids, CancellationToken cancellationToken)
    {
        var aggregateRoots = await GetManyAsync(ids, cancellationToken);
        return ids.ToDictionary(k => k, v => aggregateRoots.ContainsKey(v));
    }

    public async Task PersistAsync(
        IReadOnlyCollection<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken, bool save = true)
    {
        foreach (var aggregateRoot in aggregateRoots)
            await PersistAsync(aggregateRoot, cancellationToken, save: false);

        await TrySaveAsync(save, cancellationToken);
    }

    public async Task PersistAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken, bool save = true)
    {
        var entry = _context.Entry(aggregateRoot);
        var userId = _userContextProvider.Get()?.UserId;

        switch (entry.State)
        {
            case EntityState.Modified:
            {
                aggregateRoot.Update(new AggregateStateChangeInfo(userId, _dateTimeProvider.Now()));
                break;
            }
            case EntityState.Detached:
            {
                aggregateRoot.Init(new AggregateStateChangeInfo(userId, _dateTimeProvider.Now()));
                await _aggregateRootContext.AddAsync(aggregateRoot, cancellationToken);
                break;
            }
            default:
                return;
        }

        await TrySaveAsync(save, cancellationToken);
    }

    public Task RemoveAsync(
        IReadOnlyCollection<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken, bool save = true)
    {
        aggregateRoots.ForEach(root =>
            root.Remove(new AggregateStateChangeInfo(_userContextProvider.Get()?.UserId, _dateTimeProvider.Now())));
        _aggregateRootContext.RemoveRange(aggregateRoots);
        return TrySaveAsync(save, cancellationToken);
    }

    public Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken, bool save = true)
    {
        aggregateRoot.Remove(new AggregateStateChangeInfo(_userContextProvider.Get()?.UserId, _dateTimeProvider.Now()));
        _aggregateRootContext.Remove(aggregateRoot);
        return TrySaveAsync(save, cancellationToken);
    }

    public async Task SaveAsync(CancellationToken cancellationToken) =>
        await _context.SaveChangesAsync(cancellationToken);

    protected virtual void SetDependencies(TAggregateRoot aggregateRoot)
    {
    }

    private void TrySetAggregateRoot(TAggregateRoot? aggregateRoot)
    {
        if (aggregateRoot is null)
            return;

        SetDependencies(aggregateRoot);
    }

    private TAggregateRoot? GetFromLocal(Func<TAggregateRoot, bool> condition) =>
        _aggregateRootContext.Local.FirstOrDefault(condition);

    private List<TAggregateRoot> GetManyFromLocal(Func<TAggregateRoot, bool> condition) =>
        _aggregateRootContext.Local.Where(condition).ToList();

    private bool ExistsLocal(Func<TAggregateRoot, bool> condition) =>
        _aggregateRootContext.Local.Any(condition);

    private Task TrySaveAsync(bool save, CancellationToken cancellationToken) =>
        save ? SaveAsync(cancellationToken) : Task.FromResult(false);
}