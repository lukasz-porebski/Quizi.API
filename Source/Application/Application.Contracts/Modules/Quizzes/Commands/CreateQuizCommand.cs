using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.ValueObjects;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Commands;

public record CreateQuizCommand(
    AggregateId Id,
    string Title,
    string? Description,
    QuizSettings Settings,
    IReadOnlyCollection<QuizPersistOpenQuestionData> OpenQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> MultipleChoiceQuestions
) : ICommand;