namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizPersistOpenQuestionData(
    int OrdinalNumber,
    string Text,
    string Answer
);