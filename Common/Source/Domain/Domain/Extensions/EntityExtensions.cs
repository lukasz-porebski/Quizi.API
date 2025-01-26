using Common.Domain.Entities;
using Common.Domain.ValueObjects;

namespace Common.Domain.Extensions;

public static class EntityExtensions
{
    public static EntityNo NextNo(this IEnumerable<BaseEntity> source)
    {
        var array = source.ToArray();
        return array.Any() ? array.Max(t => t.No) + EntityNo.Generate() : EntityNo.Generate();
    }
}