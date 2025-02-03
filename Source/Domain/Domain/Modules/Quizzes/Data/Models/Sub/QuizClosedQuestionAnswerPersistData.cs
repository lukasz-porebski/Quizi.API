namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizClosedQuestionAnswerPersistData(
    int OrderNumber,
    string Text,
    bool IsCorrect
);