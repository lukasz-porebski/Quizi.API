namespace PublishedLanguage.Modules.Quizzes.Responses;

public class QuizDetailsClosedQuestionViewModel
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required IReadOnlyCollection<QuizDetailsClosedQuestionAnswerViewModel> Answers { get; set; }
}