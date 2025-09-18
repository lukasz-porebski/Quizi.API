namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizPersistClosedQuestionAnswerRequest(
    int OrdinalNumber,
    string Text,
    bool IsCorrect
);