using Domain.Contracts.Modules.Quizzes.Enums;

namespace Application.Contracts.Modules.Quizzes.Dtos;

public class QuizDetailsDto
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public TimeSpan Duration { get; init; }
    public int QuestionsCountInRunningQuiz { get; init; }
    public bool RandomQuestions { get; init; }
    public bool RandomAnswers { get; init; }
    public bool NegativePoints { get; init; }
    public QuizCopyMode CopyMode { get; init; }
    public required IReadOnlyCollection<QuizDetailsOpenQuestionDto> OpenQuestions { get; set; }
    public required IReadOnlyCollection<QuizDetailsChoiceQuestionDto> SingleChoiceQuestions { get; set; }
    public required IReadOnlyCollection<QuizDetailsChoiceQuestionDto> MultipleChoiceQuestions { get; set; }
}