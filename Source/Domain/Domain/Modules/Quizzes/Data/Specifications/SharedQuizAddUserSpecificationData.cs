using Common.Domain.ValueObjects;
using Domain.Shared.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public record SharedQuizAddUserSpecificationData(
    IReadOnlyCollection<AggregateId> CurrentUsers,
    AggregateId NewUser,
    AggregateId OwnerId,
    AggregateId UserId
) : IOwnerSpecification;