using Domain.Modules.Quizzes.Data.Models;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Commands;

public record AddNewQuestionsToQuizCommand(AggregateId Id, QuizAddNewQuestionsData Data) : ICommand;