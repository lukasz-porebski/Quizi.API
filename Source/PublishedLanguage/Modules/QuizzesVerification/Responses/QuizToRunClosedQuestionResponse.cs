namespace PublishedLanguage.Modules.QuizzesVerification.Responses;

public class QuizToRunClosedQuestionResponse
{
    public required int No { get; init; }
    public required int OrdinalNumber { get; init; }
    public required string Text { get; init; }
    public required IReadOnlyCollection<QuizToRunClosedQuestionAnswerResponse> Answers { get; set; }
}