using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Commands;

public record RemoveQuizCommand(AggregateId Id) : ICommand;