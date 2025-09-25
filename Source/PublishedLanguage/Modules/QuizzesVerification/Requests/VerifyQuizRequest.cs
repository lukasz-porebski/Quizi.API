using Common.PublishedLanguage.ViewModels;
using PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

namespace PublishedLanguage.Modules.QuizzesVerification.Requests;

public record VerifyQuizRequest(
    string QuizId,
    PeriodViewModel<DateTime> QuizRunningPeriod,
    IReadOnlyCollection<VerifyQuizOpenQuestionRequest> OpenQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionRequest> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionRequest> MultipleChoiceQuestions
);