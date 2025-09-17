namespace PublishedLanguage.Modules.Quizzes.Responses;

public class QuizDetailsOpenQuestionViewModel
{
    public int No { get; init; }
    public int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required string Answer { get; init; }
}