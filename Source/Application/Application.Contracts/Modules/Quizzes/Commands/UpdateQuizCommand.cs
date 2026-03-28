using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.ValueObjects;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Domain.Data;
using LP.Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Quizzes.Commands;

public record UpdateQuizCommand(
    AggregateId Id,
    string Title,
    string? Description,
    QuizSettings Settings,
    IReadOnlyCollection<EntityPersistData<QuizPersistOpenQuestionData>> OpenQuestions,
    IReadOnlyCollection<EntityPersistData<QuizUpdateClosedQuestionData>> SingleChoiceQuestions,
    IReadOnlyCollection<EntityPersistData<QuizUpdateClosedQuestionData>> MultipleChoiceQuestions
) : ICommand;