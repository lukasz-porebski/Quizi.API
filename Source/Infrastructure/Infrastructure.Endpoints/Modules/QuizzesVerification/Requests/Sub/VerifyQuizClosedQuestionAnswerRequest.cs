namespace Infrastructure.Endpoints.Modules.QuizzesVerification.Requests.Sub;

public record VerifyQuizClosedQuestionAnswerRequest(
    int No,
    int OrdinalNumber
);