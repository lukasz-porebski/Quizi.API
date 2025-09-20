using Common.PublishedLanguage.Requests;

namespace PublishedLanguage.Modules.QuizResults.Responses;

public class QuizResultDetailsResponse
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public PeriodRequest<DateTime> QuizRunningPeriod { get; init; } = null!;
    public TimeSpan MaxDuration { get; init; }
    public bool NegativePoints { get; init; }
    public bool RandomQuestions { get; init; }
    public bool RandomAnswers { get; init; }
    public required IReadOnlyCollection<QuizResultDetailsOpenQuestionResponse> OpenQuestions { get; set; }
    public required IReadOnlyCollection<QuizResultDetailsSingleChoiceQuestionResponse> SingleChoiceQuestions { get; set; }
    public required IReadOnlyCollection<QuizResultDetailsMultipleChoiceQuestionResponse> MultipleChoiceQuestions { get; set; }
}