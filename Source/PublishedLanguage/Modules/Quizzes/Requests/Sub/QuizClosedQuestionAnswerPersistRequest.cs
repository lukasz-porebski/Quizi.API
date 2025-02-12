namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizClosedQuestionAnswerPersistRequest(
    int OrdinalNumber,
    string Text,
    bool IsCorrect
);