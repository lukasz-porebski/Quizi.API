using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.SharedQuizzes.Commands;

public record AddQuizUserCommand(AggregateId QuizId, AggregateId UserId) : ICommand;