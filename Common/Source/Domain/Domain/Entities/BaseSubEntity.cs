using Common.Domain.Interfaces;
using Common.Domain.ValueObjects;

namespace Common.Domain.Entities;

public class BaseSubEntity(AggregateId id, EntityNo no, EntityNo subNo) : BaseEntityCore(id), IUpdateableEntity
{
    protected BaseSubEntity() : this(null!, null!, null!)
    {
    }

    public EntityNo SubNo { get; private set; } = subNo;
    protected EntityNo No { get; private set; } = no;

    EntityNo IUpdateableEntity.No => SubNo;
}