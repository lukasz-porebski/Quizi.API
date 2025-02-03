using Common.Domain.Data;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Models;

public record QuizPersistData(
    AggregateId OwnerId,
    string Title,
    string? Description,
    QuizSettings Settings,
    IReadOnlyCollection<EntityPersistData<QuizOpenQuestionPersistData>> OpenQuestions,
    IReadOnlyCollection<EntityPersistData<QuizClosedQuestionPersistData>> SingleChoiceQuestions,
    IReadOnlyCollection<EntityPersistData<QuizClosedQuestionPersistData>> MultipleChoiceQuestions
);