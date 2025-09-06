namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizDetailsChoiceQuestionDto
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required IReadOnlyCollection<QuizDetailsChoiceQuestionAnswerDto> Answers { get; set; }
}