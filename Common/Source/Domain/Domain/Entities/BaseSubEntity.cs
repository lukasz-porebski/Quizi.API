using Common.Domain.ValueObjects;

namespace Common.Domain.Entities;

public class BaseSubEntity(AggregateId id, EntityNo no, EntityNo subNo) : BaseEntity(id, no)
{
    protected BaseSubEntity() : this(null!, null!, null!)
    {
    }

    public EntityNo SubNo { get; private set; } = subNo;
}