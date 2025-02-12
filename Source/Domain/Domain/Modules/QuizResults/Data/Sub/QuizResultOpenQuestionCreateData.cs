namespace Domain.Modules.QuizResults.Data.Sub;

public record QuizResultOpenQuestionCreateData(
    int OrdinalNumber,
    string Text,
    string CorrectAnswer,
    string GivenAnswer,
    float ScoredPoints,
    float PointsPossibleToGet,
    bool? IsCorrect
);