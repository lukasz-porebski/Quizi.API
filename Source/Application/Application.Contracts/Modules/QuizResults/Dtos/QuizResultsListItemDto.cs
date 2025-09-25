namespace Application.Contracts.Modules.QuizResults.Dtos;

public class QuizResultsListItemDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required int ScoredPoints { get; set; }
    public required int PointsPossibleToGet { get; set; }
    public DateTime QuizRunningPeriodStart { get; set; }
    public DateTime QuizRunningPeriodEnd { get; set; }
    public TimeSpan Duration { get; set; }
    public TimeSpan MaxDuration { get; set; }
    public DateTime CreatedAt { get; set; }
}