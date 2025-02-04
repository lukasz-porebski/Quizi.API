using Common.Domain.Data;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Interfaces;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Data.Models;

public record QuizUpdateData(
    AggregateId OwnerId,
    string Title,
    string? Description,
    QuizSettings Settings,
    IReadOnlyCollection<EntityPersistData<QuizOpenQuestionPersistData>> OpenQuestions,
    IReadOnlyCollection<EntityPersistData<QuizClosedQuestionPersistData>> SingleChoiceQuestions,
    IReadOnlyCollection<EntityPersistData<QuizClosedQuestionPersistData>> MultipleChoiceQuestions
) : IQuizPersistData
{
    IReadOnlyCollection<QuizOpenQuestionPersistData> IQuizPersistData.OpenQuestions =>
        OpenQuestions.Select(o => o.Data).ToArray();

    IReadOnlyCollection<QuizClosedQuestionCreateData> IQuizPersistData.SingleChoiceQuestions =>
        SingleChoiceQuestions.Select(o => new QuizClosedQuestionCreateData(
            o.Data.OrderNumber, o.Data.Text, o.Data.Answers.Select(a => a.Data).ToArray())).ToArray();

    IReadOnlyCollection<QuizClosedQuestionCreateData> IQuizPersistData.MultipleChoiceQuestions =>
        MultipleChoiceQuestions.Select(o => new QuizClosedQuestionCreateData(
            o.Data.OrderNumber, o.Data.Text, o.Data.Answers.Select(a => a.Data).ToArray())).ToArray();
}