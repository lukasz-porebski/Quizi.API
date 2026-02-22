using Common.Domain.Attributes;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects;

[ValueObject]
public record EntityNo : IComparable<EntityNo>, IComparable
{
    private readonly int _entityNo;
    private const int MinValue = 1;

    public EntityNo(int entityNo)
    {
        if (entityNo < MinValue)
            throw new DomainLogicException("Entity no must be greater than zero");

        _entityNo = entityNo;
    }

    public static EntityNo Generate() =>
        new(MinValue);

    public int ToInt() =>
        _entityNo;

    public static EntityNo operator +(EntityNo? left, EntityNo? right)
    {
        left ??= new EntityNo(0);
        right ??= new EntityNo(0);

        return new EntityNo(left._entityNo + right._entityNo);
    }

    public static EntityNo operator ++(EntityNo? left) =>
        new((left ?? new EntityNo(0))._entityNo + 1);

    public static bool operator <(EntityNo? left, EntityNo? right) =>
        left?._entityNo < right?._entityNo;

    public static bool operator >(EntityNo? left, EntityNo? right) =>
        left?._entityNo > right?._entityNo;

    public static bool operator <=(EntityNo? left, EntityNo? right) =>
        left?._entityNo <= right?._entityNo;

    public static bool operator >=(EntityNo? left, EntityNo? right) =>
        left?._entityNo >= right?._entityNo;

    public int CompareTo(EntityNo? other)
    {
        if (other == null)
            return -1;

        return _entityNo.CompareTo(other._entityNo);
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return 1;

        return obj is EntityNo other
            ? CompareTo(other)
            : throw new DomainLogicException("Cannot compare objects of different types");
    }

    public override int GetHashCode() =>
        _entityNo;
}