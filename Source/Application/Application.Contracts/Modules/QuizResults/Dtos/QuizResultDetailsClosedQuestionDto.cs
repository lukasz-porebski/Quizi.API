namespace Application.Contracts.Modules.QuizResults.Dtos;

public class QuizResultDetailsClosedQuestionDto
{
    public required int No { get; init; }
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required float ScoredPoints { get; init; }
    public required float PointsPossibleToGet { get; init; }
    public required IReadOnlyCollection<QuizResultDetailsClosedQuestionAnswerDto> Answers { get; set; }
}