using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Models;

public record QuizCreateData(
    AggregateId OwnerId,
    string Title,
    string? Description,
    QuizSettings Settings,
    IReadOnlyCollection<QuizOpenQuestionPersistData> OpenQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> MultipleChoiceQuestions
) : IQuizPersistData;