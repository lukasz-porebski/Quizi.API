namespace PublishedLanguage.Modules.QuizzesVerification.Responses;

public class QuizToRunResponse
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required TimeSpan Duration { get; init; }
    public required IReadOnlyCollection<QuizToRunOpenQuestionResponse> OpenQuestions { get; set; }
    public required IReadOnlyCollection<QuizToRunClosedQuestionResponse> SingleChoiceQuestions { get; set; }
    public required IReadOnlyCollection<QuizToRunClosedQuestionResponse> MultipleChoiceQuestions { get; set; }
}