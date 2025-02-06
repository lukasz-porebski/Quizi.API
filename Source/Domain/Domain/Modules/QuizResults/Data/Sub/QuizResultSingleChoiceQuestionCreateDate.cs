namespace Domain.Modules.QuizResults.Data.Sub;

public record QuizResultSingleChoiceQuestionCreateDate(
    int OrdinalNumber,
    string Text,
    float ScoredPoints,
    float PointsPossibleToGet,
    IReadOnlyCollection<QuizResultClosedQuestionAnswerCreateData> Answers
);