using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data;
using Domain.Modules.Quizzes.Data.Questions.Create;
using Domain.Modules.Quizzes.Data.Questions.Update;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Quizzes.Specifications.Data;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes;

internal static class QuizMapper
{
    internal static List<OpenEndedQuestionEntity> ToEntities(this List<QuizOpenEndedQuestionCreateData> source)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new OpenEndedQuestionEntity(firstEntityId++, q)).ToList();
    }

    internal static List<SingleChoiceQuestionEntity> ToEntities(this List<QuizSingleChoiceQuestionCreateData> source)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new SingleChoiceQuestionEntity(firstEntityId++, q)).ToList();
    }

    internal static List<MultipleChoiceQuestionEntity> ToEntities(this List<QuizMultipleChoiceQuestionCreateData> source)
    {
        var firstEntityId = EntityNo.Generate();

        return source.Select(q => new MultipleChoiceQuestionEntity(firstEntityId++, q)).ToList();
    }

    internal static QuizPersistSpecificationData ToSpecificationData(this QuizCreateData source) =>
        new(
            questionsCountInRunningQuiz: source.Settings.QuestionsCountInRunningQuiz.ToInt(),
            openEndedQuestions: source.OpenEndedQuestions.Select(q => q.ToSpecificationData()),
            singleChoiceQuestions: source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()),
            multipleChoiceQuestions: source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()),
            owner: source.Owner,
            userDeclaredAsOwner: source.Owner);

    internal static QuizPersistSpecificationData ToSpecificationData(
        this QuizUpdateData source, AggregateId ownerId) =>
        new(
            questionsCountInRunningQuiz: source.Settings.QuestionsCountInRunningQuiz.ToInt(),
            openEndedQuestions: source.OpenEndedQuestions.Select(q => q.ToSpecificationData()),
            singleChoiceQuestions: source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()),
            multipleChoiceQuestions: source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()),
            owner: ownerId,
            userDeclaredAsOwner: source.OwnerId);

    internal static QuizOpenEndedQuestionSpecificationData ToSpecificationData(this QuizOpenEndedQuestionCreateData source) =>
        new(
            orderNumber: source.OrderNumber,
            text: source.Text,
            correctAnswer: source.CorrectAnswer);

    internal static QuizSingleChoiceQuestionSpecificationData ToSpecificationData(this QuizSingleChoiceQuestionCreateData source) =>
        new(
            orderNumber: source.OrderNumber,
            text: source.Text,
            correctAnswer: source.CorrectAnswer,
            wrongAnswers: source.WrongAnswers);

    internal static QuizMultipleChoiceQuestionSpecificationData ToSpecificationData(this QuizMultipleChoiceQuestionCreateData source) =>
        new(
            orderNumber: source.OrderNumber,
            text: source.Text,
            correctAnswers: source.CorrectAnswers,
            wrongAnswers: source.WrongAnswers);

    internal static QuizOpenEndedQuestionSpecificationData ToSpecificationData(this QuizOpenEndedQuestionUpdateData source) =>
        new(
            orderNumber: source.OrderNumber,
            text: source.Text,
            correctAnswer: source.CorrectAnswer);

    internal static QuizSingleChoiceQuestionSpecificationData ToSpecificationData(this QuizSingleChoiceQuestionUpdateData source) =>
        new(
            orderNumber: source.OrderNumber,
            text: source.Text,
            correctAnswer: source.CorrectAnswer,
            wrongAnswers: source.WrongAnswers);

    internal static QuizMultipleChoiceQuestionSpecificationData ToSpecificationData(this QuizMultipleChoiceQuestionUpdateData source) =>
        new(
            orderNumber: source.OrderNumber,
            text: source.Text,
            correctAnswers: source.CorrectAnswers,
            wrongAnswers: source.WrongAnswers);

    internal static QuizAddNewQuestionsSpecificationData ToSpecificationData(
        this QuizAddNewQuestionsData source, AggregateId ownerId,
        IReadOnlyList<OpenEndedQuestionEntity> oldOpenEndedQuestions,
        IReadOnlyList<SingleChoiceQuestionEntity> oldSingleChoiceQuestions,
        IReadOnlyList<MultipleChoiceQuestionEntity> oldMultipleChoiceQuestions) =>
        new(
            declaredQuestionsCount: source.QuestionsCountInRunningQuiz.ToInt(),
            questions: new QuizQuestionsForAddNewQuestionsSpecificationData(
                newOpenEndedQuestions: source.OpenEndedQuestions.Select(q => q.ToSpecificationData()),
                newSingleChoiceQuestions: source.SingleChoiceQuestions.Select(q => q.ToSpecificationData()),
                newMultipleChoiceQuestions: source.MultipleChoiceQuestions.Select(q => q.ToSpecificationData()),
                oldOpenEndedQuestions: oldOpenEndedQuestions,
                oldSingleChoiceQuestions: oldSingleChoiceQuestions,
                oldMultipleChoiceQuestions: oldMultipleChoiceQuestions),
            ownerId: ownerId,
            userId: source.UserId);
}