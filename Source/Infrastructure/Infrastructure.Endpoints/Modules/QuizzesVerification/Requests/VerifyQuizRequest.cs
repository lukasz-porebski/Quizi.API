using Infrastructure.Endpoints.Modules.QuizzesVerification.Requests.Sub;
using LP.Common.Infrastructure.Endpoints.ViewModels;

namespace Infrastructure.Endpoints.Modules.QuizzesVerification.Requests;

public record VerifyQuizRequest(
    string QuizId,
    PeriodViewModel<DateTime> QuizRunningPeriod,
    IReadOnlyCollection<VerifyQuizOpenQuestionRequest> OpenQuestions,
    IReadOnlyCollection<VerifyQuizSingleChoiceQuestionRequest> SingleChoiceQuestions,
    IReadOnlyCollection<VerifyQuizMultipleChoiceQuestionRequest> MultipleChoiceQuestions
);