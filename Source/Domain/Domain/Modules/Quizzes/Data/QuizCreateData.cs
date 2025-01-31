using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data;

public record QuizCreateData(
    AggregateId Id,
    AggregateId Owner,
    string Title,
    string Description,
    QuizSettings Settings,
    IReadOnlyCollection<QuizOpenQuestionCreateData> OpenQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionCreateData> MultipleChoiceQuestions
);