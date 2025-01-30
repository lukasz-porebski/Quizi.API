using Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Specifications.Interfaces;

public interface IQuizOwnerSpecification
{
    AggregateId OwnerId { get; }
    AggregateId UserId { get; }
}