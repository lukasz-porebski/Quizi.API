using Common.Domain.ValueObjects;

namespace Common.Domain.Entities;

public abstract class BaseEntityCore(AggregateId id)
{
    protected BaseEntityCore() : this(null!)
    {
    }

    private AggregateId Id { get; set; } = id;
}