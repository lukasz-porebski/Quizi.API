using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;

namespace Domain.Modules.Quizzes.Data.Models;

public record QuizAddNewQuestionsData(
    AggregateId UserId,
    int QuestionsCountInRunningQuiz,
    IReadOnlyCollection<QuizPersistOpenQuestionData> OpenQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateData> MultipleChoiceQuestions
);