using Common.PublishedLanguage.Requests;
using PublishedLanguage.Modules.QuizResults.Requests.Sub;

namespace PublishedLanguage.Modules.QuizResults.Requests;

public record VerifyQuizRequest(
    string QuizId,
    PeriodRequest QuizRunningPeriod,
    IReadOnlyCollection<VerifyQuizOpenQuestionRequest> OpenQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionRequest> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionRequest> MultipleChoiceQuestions
);