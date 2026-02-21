namespace Application.Contracts.Modules.QuizzesVerification.Data;

public record QuizToRunData(
    string Id,
    string Title,
    TimeSpan Duration,
    IReadOnlyCollection<QuizToRunOpenQuestionData> OpenQuestions,
    IReadOnlyCollection<QuizToRunClosedQuestionData> SingleChoiceQuestions,
    IReadOnlyCollection<QuizToRunClosedQuestionData> MultipleChoiceQuestions
);