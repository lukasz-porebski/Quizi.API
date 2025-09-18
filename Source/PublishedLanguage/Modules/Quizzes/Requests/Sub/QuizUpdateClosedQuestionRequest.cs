using Common.PublishedLanguage.Requests;

namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizUpdateClosedQuestionRequest(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<EntityPersistRequest<QuizPersistClosedQuestionAnswerRequest>> Answers
);