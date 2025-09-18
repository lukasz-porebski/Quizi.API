using PublishedLanguage.Modules.Quizzes.Requests.Sub;

namespace PublishedLanguage.Modules.Quizzes.Requests;

public record CreateQuizRequest(
    string Title,
    string? Description,
    QuizSettingsPersistRequest Settings,
    IReadOnlyCollection<QuizPersistOpenQuestionRequest> OpenQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateRequest> SingleChoiceQuestions,
    IReadOnlyCollection<QuizClosedQuestionCreateRequest> MultipleChoiceQuestions
);