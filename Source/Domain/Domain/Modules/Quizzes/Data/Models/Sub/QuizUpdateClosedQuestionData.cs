using Common.Domain.Data;

namespace Domain.Modules.Quizzes.Data.Models.Sub;

public record QuizUpdateClosedQuestionData(
    int OrdinalNumber,
    string Text,
    IReadOnlyCollection<EntityPersistData<QuizPersistClosedQuestionAnswerData>> Answers
);