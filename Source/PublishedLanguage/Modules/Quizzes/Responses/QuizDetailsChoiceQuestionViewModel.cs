namespace PublishedLanguage.Modules.Quizzes.Responses;

public class QuizDetailsChoiceQuestionViewModel
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required IReadOnlyCollection<QuizDetailsChoiceQuestionAnswerViewModel> Answers { get; set; }
}