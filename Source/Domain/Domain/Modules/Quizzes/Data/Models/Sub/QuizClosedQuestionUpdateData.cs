using Common.Domain.Data;

namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizClosedQuestionUpdateData(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<EntityPersistData<QuizClosedQuestionAnswerPersistData>> Answers
);