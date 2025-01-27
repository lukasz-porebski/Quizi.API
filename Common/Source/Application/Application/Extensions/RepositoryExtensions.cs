using System.Linq.Expressions;
using Common.Application.Contracts.Interfaces;
using Common.Application.Exceptions;
using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;

namespace Common.Application.Extensions;

public static class RepositoryExtensions
{
    public static async Task<TAggregateRoot> GetOrThrowAsync<TAggregateRoot>(
        this IRepository<TAggregateRoot> source,
        AggregateId id,
        string messageCode,
        CancellationToken cancellationToken)
        where TAggregateRoot : BaseAggregateRoot =>
        await source.GetAsync(id, cancellationToken) ?? throw new BusinessLogicException(messageCode);

    public static async Task<IReadOnlyDictionary<AggregateId, TAggregateRoot>> GetManyOrThrowAsync<TAggregateRoot>(
        this IRepository<TAggregateRoot> source,
        IReadOnlyCollection<AggregateId> ids,
        string messageCode,
        CancellationToken cancellationToken)
        where TAggregateRoot : BaseAggregateRoot
    {
        var result = await source.GetManyAsync(ids, cancellationToken);
        if (!result.Keys.CollectionEqual(ids))
            throw new BusinessLogicException(messageCode);

        return result;
    }

    public static async Task NotExistsOrThrowAsync<TAggregateRoot>(
        this IRepository<TAggregateRoot> source,
        Expression<Func<TAggregateRoot, bool>> condition,
        string messageCode,
        CancellationToken cancellationToken)
        where TAggregateRoot : BaseAggregateRoot
    {
        if (await source.ExistsAsync(condition, cancellationToken))
            throw new BusinessLogicException(messageCode);
    }
    
    public static async Task ExistsOrThrowAsync<TAggregateRoot>(
        this IRepository<TAggregateRoot> source,
        Expression<Func<TAggregateRoot, bool>> condition,
        string messageCode,
        CancellationToken cancellationToken)
        where TAggregateRoot : BaseAggregateRoot
    {
        if (!await source.ExistsAsync(condition, cancellationToken))
            throw new BusinessLogicException(messageCode);
    }

    public static Task ExistsOrThrowAsync<TAggregateRoot>(
        this IRepository<TAggregateRoot> source,
        AggregateId id,
        string messageCode,
        CancellationToken cancellationToken)
        where TAggregateRoot : BaseAggregateRoot =>
        source.ExistsOrThrowAsync(e => e.Id == id, messageCode, cancellationToken);

    public static async Task ExistsOrThrowAsync<TAggregateRoot>(
        this IRepository<TAggregateRoot> source,
        IReadOnlyCollection<AggregateId> ids,
        string messageCode,
        CancellationToken cancellationToken)
        where TAggregateRoot : BaseAggregateRoot
    {
        if ((await source.ExistsAsync(ids, cancellationToken)).Any(e => !e.Value))
            throw new BusinessLogicException(messageCode);
    }
}