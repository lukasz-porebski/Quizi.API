using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Commands;

public record CopyQuizCommand(Guid Code) : ICommand
{
    public AggregateId NewQuizId { get; init; } = AggregateId.Generate();
}