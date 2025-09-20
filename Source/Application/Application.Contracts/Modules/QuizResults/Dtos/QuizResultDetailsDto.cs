namespace Application.Contracts.Modules.QuizResults.Dtos;

public class QuizResultDetailsDto
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required DateTime QuizRunningPeriodStart { get; init; }
    public required DateTime QuizRunningPeriodEnd { get; init; }
    public required TimeSpan MaxDuration { get; init; }
    public required bool NegativePoints { get; init; }
    public required bool RandomQuestions { get; init; }
    public required bool RandomAnswers { get; init; }
    public required IReadOnlyCollection<QuizResultDetailsOpenQuestionDto> OpenQuestions { get; set; }
    public required IReadOnlyCollection<QuizResultDetailsClosedQuestionDto> SingleChoiceQuestions { get; set; }
    public required IReadOnlyCollection<QuizResultDetailsClosedQuestionDto> MultipleChoiceQuestions { get; set; }
}