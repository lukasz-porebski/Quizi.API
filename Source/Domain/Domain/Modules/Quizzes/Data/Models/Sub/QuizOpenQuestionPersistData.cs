namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizOpenQuestionPersistData(
    int OrderNumber,
    string Text,
    string Answer
);