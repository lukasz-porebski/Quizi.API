namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizOpenQuestionPersistData(
    int OrdinalNumber,
    string Text,
    string Answer
);