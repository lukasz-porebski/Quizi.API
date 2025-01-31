using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Questions.Update;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Models;

public record QuizUpdateData(
    string Title,
    string? Description,
    QuizSettings Settings,
    IReadOnlyCollection<QuizOpenQuestionUpdateData> OpenQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionUpdateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionUpdateData> MultipleChoiceQuestions,
    AggregateId OwnerId
);