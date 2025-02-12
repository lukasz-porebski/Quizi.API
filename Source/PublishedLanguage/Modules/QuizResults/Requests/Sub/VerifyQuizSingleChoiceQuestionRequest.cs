namespace PublishedLanguage.Modules.QuizResults.Requests.Sub;

public record VerifyQuizSingleChoiceQuestionRequest(
    int No,
    int OrdinalNumber,
    VerifyQuizClosedQuestionAnswerRequest? SelectedAnswer,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerRequest> UnselectedAnswers
);