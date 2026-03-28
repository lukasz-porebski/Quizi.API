using Infrastructure.Endpoints.Modules.Quizzes.Requests.Sub;
using LP.Common.Infrastructure.Endpoints.Requests;

namespace Infrastructure.Endpoints.Modules.Quizzes.Requests;

public record UpdateQuizRequest(
    string Id,
    string Title,
    string? Description,
    QuizSettingsPersistRequest Settings,
    IReadOnlyCollection<EntityPersistRequest<QuizPersistOpenQuestionRequest>> OpenQuestions,
    IReadOnlyCollection<EntityPersistRequest<QuizUpdateClosedQuestionRequest>> SingleChoiceQuestions,
    IReadOnlyCollection<EntityPersistRequest<QuizUpdateClosedQuestionRequest>> MultipleChoiceQuestions
);