using Common.Shared.DataStructures;

namespace Common.Shared.Extensions;

public static class UniqueCollectionExtensions
{
    public static CollectionDifferences<TCurrent, TTarget, TKey> GetDifferences<TCurrent, TTarget, TKey>(
        this UniqueCollection<TKey, TCurrent> currentsByKey,
        UniqueCollection<TKey, TTarget> targetsByKey)
        where TCurrent : notnull
        where TTarget : notnull
        where TKey : notnull
    {
        var toRemove = currentsByKey
            .Where(t => !targetsByKey.ContainsKey(currentsByKey.KeyPointer(t)))
            .ToUniqueCollection(currentsByKey.KeyPointer);

        var toAdd = new UniqueCollection<TKey, TTarget>(targetsByKey.KeyPointer);
        var existing = new Dictionary<TKey, ExistingCollectionElement<TCurrent, TTarget>>();

        foreach (var value in targetsByKey)
        {
            var key = targetsByKey.KeyPointer(value);
            if (currentsByKey.TryGetValue(key, out var current))
                existing.Add(key, new ExistingCollectionElement<TCurrent, TTarget>(current, value));
            else
                toAdd.Add(value);
        }

        return new CollectionDifferences<TCurrent, TTarget, TKey>(toRemove, toAdd, existing);
    }

    public static CollectionChanges<TCurrent, TTarget, TKey> ApplyChanges<TCurrent, TTarget, TKey>(
        this UniqueCollection<TKey, TCurrent> currentsByKey,
        IEnumerable<TTarget> targets,
        Func<TTarget, TKey> keyTarget,
        Func<TTarget, TCurrent> adding,
        Action<TCurrent, TTarget> updating,
        Func<TCurrent, TTarget, bool> requireUpdate)
        where TTarget : notnull
        where TKey : notnull
        where TCurrent : notnull
    {
        var targetsByKey = new UniqueCollection<TKey, TTarget>(keyTarget, targets);
        return currentsByKey.ApplyChanges(targetsByKey, adding, updating, requireUpdate);
    }

    public static CollectionChanges<TCurrent, TTarget, TKey> ApplyChanges<TCurrent, TTarget, TKey>(
        this UniqueCollection<TKey, TCurrent> currentsByKey,
        UniqueCollection<TKey, TTarget> targetsByKey,
        Func<TTarget, TCurrent> adding,
        Action<TCurrent, TTarget> updating,
        Func<TCurrent, TTarget, bool> requireUpdate)
        where TTarget : notnull
        where TKey : notnull
        where TCurrent : notnull
    {
        var changes = currentsByKey.GetDifferences(targetsByKey);

        currentsByKey.RemoveMany(changes.ToRemove.Values);

        var updated = new UniqueCollection<TKey, TCurrent>(currentsByKey.KeyPointer);
        foreach (var (key, (current, target)) in changes.Existing)
            if (requireUpdate.Invoke(current, target))
            {
                updating.Invoke(current, target);
                updated.Add(current);
            }

        var toAdd = changes.ToAdd.Values.Select(adding.Invoke).ToList();
        currentsByKey.AddMany(toAdd);

        return new CollectionChanges<TCurrent, TTarget, TKey>(
            changes.ToRemove,
            toAdd.ToUniqueCollection(currentsByKey.KeyPointer),
            updated);
    }
}