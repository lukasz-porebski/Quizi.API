using Application.Contracts.Modules.Quizzes.Enums;

namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizToRunQuestionDto
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required QuizQuestionType Type { get; init; }
    public required IReadOnlyCollection<QuizToRunQuestionAnswerDto> Answers { get; set; }
}