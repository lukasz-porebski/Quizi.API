namespace Domain.Modules.QuizResults.Data.Sub;

public record QuizResultMultipleChoiceQuestionCreateDate(
    int OrdinalNumber,
    string Text,
    float ScoredPoints,
    float PointsPossibleToGet,
    IReadOnlyCollection<QuizResultClosedQuestionAnswerCreateData> Answers
);