using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Specifications.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Data;

public class QuizAddUserSpecificationData : IQuizOwnerSpecification
{
    internal IEnumerable<AggregateId> CurrentUsers { get; }
    internal AggregateId NewUser { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }

    internal QuizAddUserSpecificationData(
        IEnumerable<AggregateId> currentUsers, AggregateId newUser,
        AggregateId owner, AggregateId userDeclaredAsOwner)
    {
        CurrentUsers = currentUsers;
        NewUser = newUser;
        OwnerId = owner;
        UserId = userDeclaredAsOwner;
    }
}