using Application.Contracts.Modules.Quizzes.Enums;

namespace Application.Contracts.Modules.QuizzesVerification.Dtos;

public class QuizToRunQuestionAnswerDto
{
    public int No { get; init; }
    public int SubNo { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public QuizQuestionType Type { get; init; }
}