namespace PublishedLanguage.Modules.QuizResults.Responses;

public record QuizResultsListItemResponse(
    string Id,
    string Title,
    int ScoredPoints,
    int PointsPossibleToGet,
    DateTime QuizRunningPeriodStart,
    DateTime QuizRunningPeriodEnd,
    TimeSpan Duration,
    TimeSpan MaxDuration
);