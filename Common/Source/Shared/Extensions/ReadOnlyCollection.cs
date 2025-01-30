using Common.Shared.DataStructures;

namespace Common.Shared.Extensions;

public static class ReadOnlyCollection
{
    public static CollectionDifferences<TCurrent, TTarget, TKey> GetDifferences<TCurrent, TTarget, TKey>(
        this IReadOnlyCollection<TCurrent> current,
        Func<TCurrent, TKey> keyCurrent,
        IReadOnlyCollection<TTarget> target,
        Func<TTarget, TKey> keyTarget)
        where TCurrent : notnull
        where TTarget : notnull
        where TKey : notnull
    {
        var currentsByKey = new UniqueCollection<TKey, TCurrent>(keyCurrent, current);
        var targetsByKey = new UniqueCollection<TKey, TTarget>(keyTarget, target);

        return currentsByKey.GetDifferences(targetsByKey);
    }
}