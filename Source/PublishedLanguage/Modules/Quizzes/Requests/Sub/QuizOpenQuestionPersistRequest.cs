namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizOpenQuestionPersistRequest(
    int OrdinalNumber,
    string Text,
    string Answer
);