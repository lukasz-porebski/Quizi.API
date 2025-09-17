namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizDetailsClosedQuestionAnswerDto
{
    public int No { get; init; }
    public int SubNo { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public bool IsCorrect { get; init; }
}