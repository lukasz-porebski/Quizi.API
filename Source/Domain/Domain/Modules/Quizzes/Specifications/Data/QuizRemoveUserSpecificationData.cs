using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Specifications.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Data;

public class QuizRemoveUserSpecificationData : IQuizOwnerSpecification
{
    internal IEnumerable<AggregateId> CurrentUsersIds { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }
    internal AggregateId IdOfUserToRemove { get; }

    internal QuizRemoveUserSpecificationData(
        IEnumerable<AggregateId> currentUsers, AggregateId owner,
        AggregateId idDeclaredAsOwner, AggregateId idOfUserToRemove)
    {
        CurrentUsersIds = currentUsers;
        OwnerId = owner;
        UserId = idDeclaredAsOwner;
        IdOfUserToRemove = idOfUserToRemove;
    }
}