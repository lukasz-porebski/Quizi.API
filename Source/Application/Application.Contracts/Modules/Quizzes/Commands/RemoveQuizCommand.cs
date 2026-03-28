using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Commands;

public record RemoveQuizCommand(AggregateId Id) : ICommand;