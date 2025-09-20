namespace PublishedLanguage.Modules.QuizResults.Responses;

public class QuizResultDetailsOpenQuestionResponse
{
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required string CorrectAnswer { get; init; }
    public required string GivenAnswer { get; init; }
    public required float ScoredPoints { get; init; }
    public required float PointsPossibleToGet { get; init; }
    public required bool? IsCorrect { get; init; }
}