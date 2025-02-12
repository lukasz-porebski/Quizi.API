using Common.PublishedLanguage.Requests;

namespace PublishedLanguage.Modules.Quizzes.Requests.Sub;

public record QuizClosedQuestionUpdateRequest(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<EntityPersistRequest<QuizClosedQuestionAnswerPersistRequest>> Answers
);