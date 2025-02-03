using Common.Domain.ValueObjects;
using Domain.Shared.Interfaces;

namespace Domain.Modules.SharedQuizzes.Data;

public record SharedQuizRemoveUserSpecificationData(
    IReadOnlyCollection<AggregateId> CurrentUserIds,
    AggregateId OwnerId,
    AggregateId IdDeclaredAsOwner,
    AggregateId IdOfUserToRemove
) : IOwnerSpecification
{
    AggregateId IOwnerSpecification.UserId => IdDeclaredAsOwner;
}