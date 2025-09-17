namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizDetailsOpenQuestionDto
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required string Answer { get; init; }
}