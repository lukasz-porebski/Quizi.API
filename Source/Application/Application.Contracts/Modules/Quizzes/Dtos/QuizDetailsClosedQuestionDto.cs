namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizDetailsClosedQuestionDto
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required IReadOnlyCollection<QuizDetailsClosedQuestionAnswerDto> Answers { get; set; }
}