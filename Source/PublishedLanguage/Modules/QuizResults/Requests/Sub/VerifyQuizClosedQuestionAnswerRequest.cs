namespace PublishedLanguage.Modules.QuizResults.Requests.Sub;

public record VerifyQuizClosedQuestionAnswerRequest(
    int No,
    int OrdinalNumber
);