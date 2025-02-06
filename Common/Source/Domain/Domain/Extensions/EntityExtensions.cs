using Common.Domain.Interfaces;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;

namespace Common.Domain.Extensions;

public static class EntityExtensions
{
    public static void ApplyChanges<TCurrent, TTarget>(
        this List<TCurrent> current,
        IReadOnlyCollection<TTarget> target,
        Func<EntityNo, TTarget, TCurrent> adding,
        Action<TCurrent, TTarget> updating,
        Func<TCurrent, TTarget, bool>? requireUpdate = null)
        where TCurrent : IUpdateableEntity
        where TTarget : IPersistableEntity
    {
        var nextNo = current.NextNo();

        var difference = current.GetDifferences(k => k.No, target.Where(t => t.No != null).ToArray(), k => k.No!);
        current.RemoveAll(entity => difference.ToRemove.Contains(entity));

        foreach (var existing in difference.Existing)
        {
            if (requireUpdate != null && !requireUpdate(existing.Value.Current, existing.Value.Target))
                continue;

            updating(existing.Value.Current, existing.Value.Target);
        }

        current.AddRange(target.Where(t => t.No == null).Select(data => adding(nextNo++, data)));
    }

    public static void ApplyNew<TCurrent, TTarget>(
        this List<TCurrent> current,
        IReadOnlyCollection<TTarget> newData,
        Func<EntityNo, TTarget, TCurrent> adding)
        where TCurrent : IUpdateableEntity
    {
        var nextNo = current.NextNo();

        current.AddRange(newData.Select(q => adding(nextNo++, q)));
    }

    private static EntityNo NextNo<TEntity>(this IEnumerable<TEntity> source)
        where TEntity : IUpdateableEntity
    {
        var array = source.ToArray();
        return array.Any() ? array.Max(t => t.No) + EntityNo.Generate() : EntityNo.Generate();
    }
}