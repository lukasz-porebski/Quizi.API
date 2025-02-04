using Common.Application.Contracts.CQRS;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;

namespace Application.Contracts.Modules.Quizzes.Commands;

public record AddNewQuestionsToQuizCommand(AggregateId Id, QuizAddNewQuestionsData Data) : ICommand;