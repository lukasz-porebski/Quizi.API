namespace PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

public record VerifyQuizMultipleChoiceQuestionRequest(
    int No,
    int OrdinalNumber,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerRequest> SelectedAnswers,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerRequest> UnselectedAnswers
);