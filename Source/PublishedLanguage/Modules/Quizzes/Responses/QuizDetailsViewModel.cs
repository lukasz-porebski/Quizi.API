using Domain.Contracts.Modules.Quizzes.Enums;

namespace PublishedLanguage.Modules.Quizzes.Responses;

public class QuizDetailsViewModel
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public TimeSpan Duration { get; init; }
    public int QuestionsCountInRunningQuiz { get; init; }
    public bool RandomQuestions { get; init; }
    public bool RandomAnswers { get; init; }
    public bool NegativePoints { get; init; }
    public QuizCopyMode CopyMode { get; init; }
    public required IReadOnlyCollection<QuizDetailsOpenQuestionViewModel> OpenQuestions { get; set; }
    public required IReadOnlyCollection<QuizDetailsClosedQuestionViewModel> SingleChoiceQuestions { get; set; }
    public required IReadOnlyCollection<QuizDetailsClosedQuestionViewModel> MultipleChoiceQuestions { get; set; }
}