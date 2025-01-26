using Common.Shared.DataStructures;

namespace Common.Shared.Extensions;

public static class CollectionExtensions
{
    public static void RemoveMany<T>(this ICollection<T> source, IEnumerable<T> collection)
    {
        foreach (var item in collection)
            source.Remove(item);
    }

    public static void AddMany<T>(this ICollection<T> source, IEnumerable<T> collection)
    {
        foreach (var item in collection)
            source.Add(item);
    }

    public static CollectionChanges<TCurrent, TTarget, TKey> ApplyChanges<TCurrent, TTarget, TKey>(
        this ICollection<TCurrent> currents,
        IEnumerable<TTarget> targets,
        Func<TCurrent, TKey> keyCurrent,
        Func<TTarget, TKey> keyTarget,
        Func<TTarget, TCurrent> adding,
        Action<TCurrent, TTarget> updating,
        Func<TCurrent, TTarget, bool> requireUpdate)
        where TTarget : notnull
        where TKey : notnull
        where TCurrent : notnull
    {
        var currentsByKey = new UniqueCollection<TKey, TCurrent>(keyCurrent, currents);
        var targetsByKey = new UniqueCollection<TKey, TTarget>(keyTarget, targets);
        return currentsByKey.ApplyChanges(targetsByKey, adding, updating, requireUpdate);
    }
}