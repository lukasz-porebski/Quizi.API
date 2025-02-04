using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.SharedQuizzes.Commands;

public record RemoveQuizUserCommand(AggregateId QuizId, AggregateId UserId) : ICommand;