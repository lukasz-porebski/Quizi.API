using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes;

internal static class QuizMapper
{
    public static QuizPersistSpecificationData ToSpecificationData(this QuizPersistData source, AggregateId ownerId) =>
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

    public static QuizAddNewQuestionsSpecificationData ToSpecificationData(
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