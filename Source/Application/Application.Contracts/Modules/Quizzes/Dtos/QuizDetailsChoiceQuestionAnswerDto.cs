namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizDetailsChoiceQuestionAnswerDto
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public bool IsCorrect { get; init; }
}