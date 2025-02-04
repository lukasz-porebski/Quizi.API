using Common.Domain.Data;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Quizzes.Models.Base;

namespace Domain.Modules.Quizzes;

public static class QuizMapper
{
    public static EntityPersistData<QuizClosedQuestionAnswerPersistData> ToPersistData(this BaseQuizClosedQuestionAnswer source) =>
        new(source.SubNo, new QuizClosedQuestionAnswerPersistData(source.OrderNumber, source.Text, source.IsCorrect));

    internal static QuizPersistSpecificationData ToSpecificationData(this QuizPersistData source, AggregateId ownerId) =>
        new(source.Settings.QuestionsCountInRunningQuiz,
            source.Title,
            source.Description,
            source.Settings.Duration,
            source.OpenQuestions.Select(q => q.Data).ToArray(),
            source.SingleChoiceQuestions.Select(q => q.Data).ToArray(),
            source.MultipleChoiceQuestions.Select(q => q.Data).ToArray(),
            ownerId,
            source.OwnerId
        );

    internal static QuizAddNewQuestionsSpecificationData ToSpecificationData(
        this QuizAddNewQuestionsData source,
        AggregateId ownerId,
        IReadOnlyList<QuizOpenQuestion> oldOpenQuestions,
        IReadOnlyList<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyList<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions) =>
        new(source.QuestionsCountInRunningQuiz,
            new QuizQuestionsForAddNewQuestionsSpecificationData(
                source.OpenQuestions,
                source.SingleChoiceQuestions,
                source.MultipleChoiceQuestions,
                oldOpenQuestions,
                oldSingleChoiceQuestions,
                oldMultipleChoiceQuestions),
            ownerId,
            source.UserId);
}