using Common.PublishedLanguage.Requests;
using PublishedLanguage.Modules.Quizzes.Requests.Sub;

namespace PublishedLanguage.Modules.Quizzes.Requests;

public record UpdateQuizRequest(
    string Id,
    string Title,
    string? Description,
    QuizSettingsPersistRequest Settings,
    IReadOnlyCollection<EntityPersistRequest<QuizOpenQuestionPersistRequest>> OpenQuestions,
    IReadOnlyCollection<EntityPersistRequest<QuizClosedQuestionUpdateRequest>> SingleChoiceQuestions,
    IReadOnlyCollection<EntityPersistRequest<QuizClosedQuestionUpdateRequest>> MultipleChoiceQuestions
);