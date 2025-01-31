using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;

namespace Domain.Modules.Quizzes.Data;

public record QuizAddNewQuestionsData(
    AggregateId UserId,
    int QuestionsCountInRunningQuiz,
    IReadOnlyCollection<QuizOpenQuestionCreateData> OpenQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionCreateData> MultipleChoiceQuestions
);