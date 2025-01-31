using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes;

internal static class QuizMapper
{
    internal static List<QuizOpenQuestion> ToEntities(
        this IReadOnlyCollection<QuizOpenQuestionCreateData> source, AggregateId id)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new QuizOpenQuestion(id, firstEntityId++, q)).ToList();
    }

    internal static List<QuizSingleChoiceQuestion> ToEntities(
        this IReadOnlyCollection<QuizSingleChoiceQuestionCreateData> source, AggregateId id)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new QuizSingleChoiceQuestion(id, firstEntityId++, q)).ToList();
    }

    internal static List<QuizMultipleChoiceQuestion> ToEntities(
        this IReadOnlyCollection<QuizMultipleChoiceQuestionCreateData> source, AggregateId id)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new QuizMultipleChoiceQuestion(id, firstEntityId++, q)).ToList();
    }

    internal static QuizPersistSpecificationData ToSpecificationData(this QuizCreateData source) =>
        new(source.Settings.QuestionsCountInRunningQuiz,
            source.OpenQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            source.Owner,
            source.Owner
        );

    internal static QuizPersistSpecificationData ToSpecificationData(
        this QuizUpdateData source, AggregateId ownerId) =>
        new(source.Settings.QuestionsCountInRunningQuiz,
            source.OpenQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            ownerId,
            source.OwnerId
        );

    internal static QuizOpenQuestionSpecificationData ToSpecificationData(this QuizOpenQuestionCreateData source) =>
        new(source.OrderNumber, source.Text, source.CorrectAnswer);

    internal static QuizSingleChoiceQuestionSpecificationData ToSpecificationData(this QuizSingleChoiceQuestionCreateData source) =>
        new(source.OrderNumber, source.Text, source.Answers);

    internal static QuizMultipleChoiceQuestionSpecificationData ToSpecificationData(this QuizMultipleChoiceQuestionCreateData source) =>
        new(source.OrderNumber, source.Text, source.Answers);

    internal static QuizOpenQuestionSpecificationData ToSpecificationData(this QuizOpenQuestionUpdateData source) =>
        new(source.OrderNumber, source.Text, source.CorrectAnswer);

    internal static QuizSingleChoiceQuestionSpecificationData ToSpecificationData(this QuizSingleChoiceQuestionUpdateData source) =>
        new(source.OrderNumber, source.Text, source.Answers);

    internal static QuizMultipleChoiceQuestionSpecificationData ToSpecificationData(this QuizMultipleChoiceQuestionUpdateData source) =>
        new(source.OrderNumber, source.Text, source.Answers);

    internal static QuizAddNewQuestionsSpecificationData ToSpecificationData(
        this QuizAddNewQuestionsData source,
        AggregateId ownerId,
        IReadOnlyList<QuizOpenQuestion> oldOpenQuestions,
        IReadOnlyList<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyList<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions) =>
        new(source.QuestionsCountInRunningQuiz,
            new QuizQuestionsForAddNewQuestionsSpecificationData(
                source.OpenQuestions.Select(q => q.ToSpecificationData()).ToArray(),
                source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
                source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
                oldOpenQuestions,
                oldSingleChoiceQuestions,
                oldMultipleChoiceQuestions),
            ownerId,
            source.UserId);
}