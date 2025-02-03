using Common.Domain.ValueObjects;
using Domain.Shared.Interfaces;

namespace Domain.Modules.SharedQuizzes.Data;

public record SharedQuizAddUserSpecificationData(
    IReadOnlyCollection<AggregateId> CurrentUsers,
    AggregateId NewUser,
    AggregateId OwnerId,
    AggregateId UserId
) : IOwnerSpecification;