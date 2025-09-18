namespace PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

public record VerifyQuizSingleChoiceQuestionRequest(
    int No,
    int OrdinalNumber,
    VerifyQuizClosedQuestionAnswerRequest? SelectedAnswer,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerRequest> UnselectedAnswers
);