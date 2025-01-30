using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data;

public record QuizAddNewQuestionsData(
    AggregateId UserId,
    QuizQuestionsCountInRunningQuiz QuestionsCountInRunningQuiz,
    IReadOnlyCollection<QuizOpenEndedQuestionCreateData> OpenEndedQuestions,
    IReadOnlyCollection<QuizSingleChoiceQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizMultipleChoiceQuestionCreateData> MultipleChoiceQuestions
);