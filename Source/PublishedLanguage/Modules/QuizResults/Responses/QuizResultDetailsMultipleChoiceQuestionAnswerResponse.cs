namespace PublishedLanguage.Modules.QuizResults.Responses;

public class QuizResultDetailsMultipleChoiceQuestionAnswerResponse
{
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required bool IsCorrect { get; init; }
    public required bool IsSelected { get; init; }
}