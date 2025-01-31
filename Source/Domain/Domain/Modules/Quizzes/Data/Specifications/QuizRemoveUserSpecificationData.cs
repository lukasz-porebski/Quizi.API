using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public record QuizRemoveUserSpecificationData(
    IReadOnlyCollection<AggregateId> CurrentUserIds,
    AggregateId OwnerId,
    AggregateId IdDeclaredAsOwner,
    AggregateId IdOfUserToRemove
) : IQuizOwnerSpecification
{
    AggregateId IQuizOwnerSpecification.UserId => IdDeclaredAsOwner;
}