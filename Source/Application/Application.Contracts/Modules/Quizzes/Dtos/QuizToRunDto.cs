namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizToRunDto
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public TimeSpan Duration { get; init; }
    public bool RandomQuestions { get; init; }
    public bool RandomAnswers { get; init; }
    public required IReadOnlyCollection<QuizToRunQuestionDto> Questions { get; set; }
}