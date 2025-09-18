namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizPersistOpenQuestionRequest(
    int OrdinalNumber,
    string Text,
    string Answer
);