namespace Common.Shared.DataStructures;

public record CollectionDifferences<TCurrent, TTarget, TKey>(
    IReadOnlyUniqueCollection<TKey, TCurrent> ToRemove,
    IReadOnlyUniqueCollection<TKey, TTarget> ToAdd,
    IReadOnlyDictionary<TKey, ExistingCollectionElement<TCurrent, TTarget>> Existing)
    where TKey : notnull
    where TCurrent : notnull
    where TTarget : notnull;

public record ExistingCollectionElement<TCurrent, TTarget>(TCurrent Current, TTarget Target);