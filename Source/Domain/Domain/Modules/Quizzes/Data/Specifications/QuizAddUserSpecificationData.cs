using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Data.Specifications;

public record QuizAddUserSpecificationData(
    IReadOnlyCollection<AggregateId> CurrentUsers,
    AggregateId NewUser,
    AggregateId OwnerId,
    AggregateId UserId
) : IQuizOwnerSpecification;