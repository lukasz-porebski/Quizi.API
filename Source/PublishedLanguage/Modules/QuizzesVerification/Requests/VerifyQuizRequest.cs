using Common.PublishedLanguage.Requests;
using PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

namespace PublishedLanguage.Modules.QuizzesVerification.Requests;

public record VerifyQuizRequest(
    string QuizId,
    PeriodRequest QuizRunningPeriod,
    IReadOnlyCollection<VerifyQuizOpenQuestionRequest> OpenQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionRequest> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionRequest> MultipleChoiceQuestions
);