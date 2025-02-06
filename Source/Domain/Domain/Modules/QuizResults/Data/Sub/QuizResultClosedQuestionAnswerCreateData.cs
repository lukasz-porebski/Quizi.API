namespace Domain.Modules.QuizResults.Data.Sub;

public record QuizResultClosedQuestionAnswerCreateData(
    int OrdinalNumber,
    string Text,
    bool IsCorrect,
    bool IsSelected
);