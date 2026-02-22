using Common.Domain.Attributes;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects;

[ValueObject]
public record AggregateId
{
    private readonly string _aggregateId;

    public AggregateId(string aggregateId)
    {
        ValidateAndThrow(aggregateId);
        _aggregateId = aggregateId;
    }

    public AggregateId(Guid aggregateId)
        : this(aggregateId.ToString())
    {
    }

    private AggregateId()
    {
        _aggregateId = Guid.Empty.ToString();
    }

    public static AggregateId Empty =>
        new();

    public static AggregateId Generate() =>
        new(Guid.NewGuid().ToString());

    public static void ValidateAndThrow(string aggregateId)
    {
        if (!Guid.TryParse(aggregateId, out var guid) || guid.Equals(Guid.Empty))
            throw new DomainLogicException("Invalid aggregate id");
    }

    public static bool TryParse(string aggregateId, out AggregateId result)
    {
        if (!Guid.TryParse(aggregateId, out var guid))
        {
            result = Empty;
            return false;
        }

        result = new AggregateId(guid.ToString());
        return true;
    }

    public override string ToString() =>
        _aggregateId;

    public override int GetHashCode() =>
        HashCode.Combine(_aggregateId);

    public Guid ToGuid() =>
        Guid.Parse(_aggregateId);
}