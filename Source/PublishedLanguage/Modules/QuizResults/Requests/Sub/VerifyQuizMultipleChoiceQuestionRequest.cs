namespace PublishedLanguage.Modules.QuizResults.Requests.Sub;

public record VerifyQuizMultipleChoiceQuestionRequest(
    int No,
    int OrdinalNumber,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerRequest> SelectedAnswers,
    IReadOnlyCollection<VerifyQuizClosedQuestionAnswerRequest> UnselectedAnswers
);