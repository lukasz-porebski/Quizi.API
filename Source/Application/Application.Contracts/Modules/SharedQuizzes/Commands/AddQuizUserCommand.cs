using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.SharedQuizzes.Commands;

public record AddQuizUserCommand(AggregateId QuizId, AggregateId UserId) : ICommand;