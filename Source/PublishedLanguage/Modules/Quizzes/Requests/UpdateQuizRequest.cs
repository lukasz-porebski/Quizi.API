using Common.PublishedLanguage.Requests;
using PublishedLanguage.Modules.Quizzes.Requests.Sub;

namespace PublishedLanguage.Modules.Quizzes.Requests;

public record UpdateQuizRequest(
    string Id,
    string Title,
    string? Description,
    QuizSettingsPersistRequest Settings,
    IReadOnlyCollection<EntityPersistRequest<QuizPersistOpenQuestionRequest>> OpenQuestions,
    IReadOnlyCollection<EntityPersistRequest<QuizUpdateClosedQuestionRequest>> SingleChoiceQuestions,
    IReadOnlyCollection<EntityPersistRequest<QuizUpdateClosedQuestionRequest>> MultipleChoiceQuestions
);