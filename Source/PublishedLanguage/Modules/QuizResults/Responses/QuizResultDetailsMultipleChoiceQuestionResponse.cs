namespace PublishedLanguage.Modules.QuizResults.Responses;

public class QuizResultDetailsMultipleChoiceQuestionResponse
{
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required float ScoredPoints { get; init; }
    public required float PointsPossibleToGet { get; init; }
    public required IReadOnlyCollection<QuizResultDetailsMultipleChoiceQuestionAnswerResponse> Answers { get; set; }
}