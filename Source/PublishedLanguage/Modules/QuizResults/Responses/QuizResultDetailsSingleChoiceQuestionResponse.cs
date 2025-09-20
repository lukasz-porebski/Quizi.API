namespace PublishedLanguage.Modules.QuizResults.Responses;

public class QuizResultDetailsSingleChoiceQuestionResponse
{
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required float ScoredPoints { get; init; }
    public required float PointsPossibleToGet { get; init; }
    public required int? SelectedAnswerOrdinalNumber { get; init; }
    public required IReadOnlyCollection<QuizResultDetailsSingleChoiceQuestionAnswerResponse> Answers { get; set; }
}