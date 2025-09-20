namespace Application.Contracts.Modules.QuizResults.Dtos;

public class QuizResultDetailsClosedQuestionAnswerDto
{
    public required int No { get; init; }
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required bool IsCorrect { get; init; }
    public required bool IsSelected { get; init; }
}