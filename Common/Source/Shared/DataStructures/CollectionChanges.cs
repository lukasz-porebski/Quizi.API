namespace Common.Shared.DataStructures;

public record CollectionChanges<TCurrent, TTarget, TKey>(
    IReadOnlyUniqueCollection<TKey, TCurrent> Removed,
    IReadOnlyUniqueCollection<TKey, TCurrent> Added,
    IReadOnlyUniqueCollection<TKey, TCurrent> Updated)
    where TKey : notnull
    where TCurrent : notnull
    where TTarget : notnull;