using Common.Infrastructure.Endpoints.ViewModels;
using Infrastructure.Endpoints.Modules.QuizzesVerification.Requests.Sub;

namespace Infrastructure.Endpoints.Modules.QuizzesVerification.Requests;

public record VerifyQuizRequest(
    string QuizId,
    PeriodViewModel<DateTime> QuizRunningPeriod,
    IReadOnlyCollection<VerifyQuizOpenQuestionRequest> OpenQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionRequest> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionRequest> MultipleChoiceQuestions
);