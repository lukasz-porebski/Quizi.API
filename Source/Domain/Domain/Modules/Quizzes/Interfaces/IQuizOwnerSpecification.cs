using Common.Domain.ValueObjects;

namespace Domain.Modules.Quizzes.Interfaces;

public interface IQuizOwnerSpecification
{
    AggregateId OwnerId { get; }
    AggregateId UserId { get; }
}