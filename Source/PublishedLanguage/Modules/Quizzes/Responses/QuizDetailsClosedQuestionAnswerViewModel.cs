namespace PublishedLanguage.Modules.Quizzes.Responses;

public class QuizDetailsClosedQuestionAnswerViewModel
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public bool IsCorrect { get; init; }
}