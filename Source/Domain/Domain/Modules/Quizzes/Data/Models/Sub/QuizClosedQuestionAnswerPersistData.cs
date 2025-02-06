namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizClosedQuestionAnswerPersistData(
    int OrdinalNumber,
    string Text,
    bool IsCorrect
);