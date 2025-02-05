using Common.Domain.Interfaces;
using Common.Domain.ValueObjects;

namespace Common.Domain.Entities;

public abstract class BaseEntity(AggregateId id, EntityNo no) : BaseEntityCore(id), IUpdateableEntity
{
    protected BaseEntity() : this(null!, null!)
    {
    }

    public EntityNo No { get; private set; } = no;
}