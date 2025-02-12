namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizClosedQuestionCreateRequest(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<QuizClosedQuestionAnswerPersistRequest> Answers
);