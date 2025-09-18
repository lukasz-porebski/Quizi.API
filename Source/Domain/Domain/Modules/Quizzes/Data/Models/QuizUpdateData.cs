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
    IReadOnlyCollection<EntityPersistData<QuizPersistOpenQuestionData>> OpenQuestions,
    IReadOnlyCollection<EntityPersistData<QuizUpdateClosedQuestionData>> SingleChoiceQuestions,
    IReadOnlyCollection<EntityPersistData<QuizUpdateClosedQuestionData>> MultipleChoiceQuestions
) : IQuizPersistData
{
    IReadOnlyCollection<QuizPersistOpenQuestionData> IQuizPersistData.OpenQuestions =>
        OpenQuestions.Select(o => o.Data).ToArray();

    IReadOnlyCollection<QuizClosedQuestionCreateData> IQuizPersistData.SingleChoiceQuestions =>
        SingleChoiceQuestions.Select(o => new QuizClosedQuestionCreateData(
            o.Data.OrdinalNumber, o.Data.Text, o.Data.Answers.Select(a => a.Data).ToArray())).ToArray();

    IReadOnlyCollection<QuizClosedQuestionCreateData> IQuizPersistData.MultipleChoiceQuestions =>
        MultipleChoiceQuestions.Select(o => new QuizClosedQuestionCreateData(
            o.Data.OrdinalNumber, o.Data.Text, o.Data.Answers.Select(a => a.Data).ToArray())).ToArray();
}