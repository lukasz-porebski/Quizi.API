using Common.Domain.Data;

namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizClosedQuestionPersistData(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<EntityPersistData<QuizClosedQuestionAnswerPersistData>> Answers
);