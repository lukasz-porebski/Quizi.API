using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;

namespace Common.Domain.Extensions;

public static class ReadOnlyCollectionExtensions
{
    public static EntityNo GetNextEntityNo<T>(this IReadOnlyCollection<T> source)
        where T : BaseEntity
    {
        if (source.IsEmpty())
            return EntityNo.Generate();

        var maxNo = source.Max(s => s.No);
        return (maxNo++)!;
    }
}