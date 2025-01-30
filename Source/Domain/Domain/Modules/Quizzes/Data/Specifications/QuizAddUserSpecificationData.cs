using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Specifications.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public record QuizAddUserSpecificationData : IQuizOwnerSpecification
{
    public AggregateId NewUser { get; }
    public AggregateId OwnerId { get; }
    public AggregateId UserId { get; }
    public IReadOnlyCollection<AggregateId> CurrentUsers { get; }

    internal QuizAddUserSpecificationData(
        IReadOnlyCollection<AggregateId> currentUsers,
        AggregateId newUser,
        AggregateId owner,
        AggregateId userDeclaredAsOwner)
    {
        CurrentUsers = currentUsers;
        NewUser = newUser;
        OwnerId = owner;
        UserId = userDeclaredAsOwner;
    }
}