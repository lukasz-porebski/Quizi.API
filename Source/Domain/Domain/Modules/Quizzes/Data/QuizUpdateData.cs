using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data;

public record QuizUpdateData(
    string Title,
    string Description,
    QuizSettings Settings,
    IReadOnlyCollection<QuizOpenEndedQuestionUpdateData> OpenEndedQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionUpdateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionUpdateData> MultipleChoiceQuestions,
    AggregateId OwnerId
);