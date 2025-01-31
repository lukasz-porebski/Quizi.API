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
    internal static List<OpenEndedQuestion> ToEntities(
        this IReadOnlyCollection<QuizOpenEndedQuestionCreateData> source, AggregateId id)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new OpenEndedQuestion(id, firstEntityId++, q)).ToList();
    }

    internal static List<SingleChoiceQuestion> ToEntities(
        this IReadOnlyCollection<QuizSingleChoiceQuestionCreateData> source, AggregateId id)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new SingleChoiceQuestion(id, firstEntityId++, q)).ToList();
    }

    internal static List<MultipleChoiceQuestion> ToEntities(
        this IReadOnlyCollection<QuizMultipleChoiceQuestionCreateData> source, AggregateId id)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new MultipleChoiceQuestion(id, firstEntityId++, q)).ToList();
    }

    internal static QuizPersistSpecificationData ToSpecificationData(this QuizCreateData source) =>
        new(
            questionsCountInRunningQuiz: source.Settings.QuestionsCountInRunningQuiz,
            openEndedQuestions: source.OpenEndedQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            singleChoiceQuestions: source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            multipleChoiceQuestions: source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            owner: source.Owner,
            userDeclaredAsOwner: source.Owner);

    internal static QuizPersistSpecificationData ToSpecificationData(
        this QuizUpdateData source, AggregateId ownerId) =>
        new(
            questionsCountInRunningQuiz: source.Settings.QuestionsCountInRunningQuiz,
            openEndedQuestions: source.OpenEndedQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            singleChoiceQuestions: source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            multipleChoiceQuestions: source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
            owner: ownerId,
            userDeclaredAsOwner: source.OwnerId);

    internal static QuizOpenEndedQuestionSpecificationData ToSpecificationData(this QuizOpenEndedQuestionCreateData source) =>
        new(
            OrderNumber: source.OrderNumber,
            Text: source.Text,
            CorrectAnswer: source.CorrectAnswer);

    internal static QuizSingleChoiceQuestionSpecificationData ToSpecificationData(this QuizSingleChoiceQuestionCreateData source) =>
        new(
            OrderNumber: source.OrderNumber,
            Text: source.Text,
            CorrectAnswer: source.CorrectAnswer,
            WrongAnswers: source.WrongAnswers);

    internal static QuizMultipleChoiceQuestionSpecificationData ToSpecificationData(this QuizMultipleChoiceQuestionCreateData source) =>
        new(
            OrderNumber: source.OrderNumber,
            Text: source.Text,
            CorrectAnswers: source.CorrectAnswers,
            WrongAnswers: source.WrongAnswers);

    internal static QuizOpenEndedQuestionSpecificationData ToSpecificationData(this QuizOpenEndedQuestionUpdateData source) =>
        new(
            OrderNumber: source.OrderNumber,
            Text: source.Text,
            CorrectAnswer: source.CorrectAnswer);

    internal static QuizSingleChoiceQuestionSpecificationData ToSpecificationData(this QuizSingleChoiceQuestionUpdateData source) =>
        new(
            OrderNumber: source.OrderNumber,
            Text: source.Text,
            CorrectAnswer: source.CorrectAnswer,
            WrongAnswers: source.WrongAnswers);

    internal static QuizMultipleChoiceQuestionSpecificationData ToSpecificationData(this QuizMultipleChoiceQuestionUpdateData source) =>
        new(
            OrderNumber: source.OrderNumber,
            Text: source.Text,
            CorrectAnswers: source.CorrectAnswers,
            WrongAnswers: source.WrongAnswers);

    internal static QuizAddNewQuestionsSpecificationData ToSpecificationData(
        this QuizAddNewQuestionsData source, AggregateId ownerId,
        IReadOnlyList<OpenEndedQuestion> oldOpenEndedQuestions,
        IReadOnlyList<SingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyList<MultipleChoiceQuestion> oldMultipleChoiceQuestions) =>
        new(
            declaredQuestionsCount: source.QuestionsCountInRunningQuiz,
            questions: new QuizQuestionsForAddNewQuestionsSpecificationData(
                newOpenEndedQuestions: source.OpenEndedQuestions.Select(q => q.ToSpecificationData()).ToArray(),
                newSingleChoiceQuestions: source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
                newMultipleChoiceQuestions: source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()).ToArray(),
                oldOpenEndedQuestions: oldOpenEndedQuestions,
                oldSingleChoiceQuestions: oldSingleChoiceQuestions,
                oldMultipleChoiceQuestions: oldMultipleChoiceQuestions),
            ownerId: ownerId,
            userId: source.UserId);
}