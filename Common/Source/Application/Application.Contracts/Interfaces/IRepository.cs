using System.Linq.Expressions;
using Common.Domain.Entities;
using Common.Domain.ValueObjects;

namespace Common.Application.Contracts.Interfaces;

public interface IRepository<TAggregateRoot>
    where TAggregateRoot : BaseAggregateRoot
{
    Task<TAggregateRoot?> GetAsync(AggregateId id, CancellationToken cancellationToken);
    Task<TAggregateRoot?> GetAsync(Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken);

    Task<IReadOnlyDictionary<AggregateId, TAggregateRoot>> GetManyAsync(
        IReadOnlyCollection<AggregateId> ids, CancellationToken cancellationToken);

    Task<IReadOnlyDictionary<AggregateId, TAggregateRoot>> GetManyAsync(
        Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken);
    Task<IReadOnlyDictionary<AggregateId, bool>> ExistsAsync(IReadOnlyCollection<AggregateId> ids, CancellationToken cancellationToken);
    Task PersistAsync(IReadOnlyCollection<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken, bool save = true);
    Task PersistAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken, bool save = true);
    Task Remove(IReadOnlyCollection<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken, bool save = true);
    Task Remove(TAggregateRoot aggregateRoot, CancellationToken cancellationToken, bool save = true);
    Task SaveAsync(CancellationToken cancellationToken);
}