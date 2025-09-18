namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizPersistClosedQuestionAnswerData(
    int OrdinalNumber,
    string Text,
    bool IsCorrect
);