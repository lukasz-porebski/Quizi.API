namespace PublishedLanguage.Modules.QuizResults.Responses;

public class QuizResultDetailsSingleChoiceQuestionAnswerResponse
{
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required bool IsCorrect { get; init; }
}