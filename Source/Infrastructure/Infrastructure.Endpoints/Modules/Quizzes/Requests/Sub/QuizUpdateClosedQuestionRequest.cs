using LP.Common.Infrastructure.Endpoints.Requests;

namespace Infrastructure.Endpoints.Modules.Quizzes.Requests.Sub;

public record QuizUpdateClosedQuestionRequest(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<EntityPersistRequest<QuizPersistClosedQuestionAnswerRequest>> Answers
);