namespace PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

public record VerifyQuizClosedQuestionAnswerRequest(
    int No,
    int OrdinalNumber
);