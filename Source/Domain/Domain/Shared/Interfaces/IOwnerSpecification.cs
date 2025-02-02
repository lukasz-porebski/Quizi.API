using Common.Domain.ValueObjects;

namespace Domain.Shared.Interfaces;

public interface IOwnerSpecification
{
    AggregateId OwnerId { get; }
    AggregateId UserId { get; }
}