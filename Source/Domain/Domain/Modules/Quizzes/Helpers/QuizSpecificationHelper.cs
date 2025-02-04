using Common.Domain.Data;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Quizzes.Models.Base;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizSpecificationHelper
{
    public static IReadOnlyCollection<QuizQuestionSpecificationData> GetQuestions(
        IReadOnlyCollection<QuizOpenQuestion> oldOpenQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions)
    {
        var openQuestions = oldOpenQuestions
            .Select(q => new QuizOpenQuestionPersistData(q.OrderNumber, q.Text, q.Answer))
            .ToArray();

        var singleChoiceQuestions = oldSingleChoiceQuestions
            .Select(q => new QuizClosedQuestionPersistData(
                q.OrderNumber, q.Text, q.Answers.Select(a => a.ToPersistData()).ToArray()))
            .ToArray();

        var multipleChoiceQuestions = oldMultipleChoiceQuestions
            .Select(q => new QuizClosedQuestionPersistData(
                q.OrderNumber, q.Text, q.Answers.Select(a => a.ToPersistData()).ToArray()))
            .ToArray();

        return GetQuestions(openQuestions, singleChoiceQuestions, multipleChoiceQuestions);
    }

    public static IReadOnlyCollection<QuizQuestionSpecificationData> GetQuestions(
        IReadOnlyCollection<QuizOpenQuestionPersistData> openQuestions,
        IReadOnlyCollection<QuizClosedQuestionPersistData> singleChoiceQuestions,
        IReadOnlyCollection<QuizClosedQuestionPersistData> multipleChoiceQuestions) =>
        openQuestions
            .Select(question => new QuizQuestionSpecificationData(
                question.OrderNumber,
                question.Text,
                new List<string> { question.Answer }))
            .Concat(singleChoiceQuestions.Select(question => new QuizQuestionSpecificationData(
                question.OrderNumber,
                question.Text,
                question.Answers.Select(a => a.Data.Text).ToArray())))
            .Concat(multipleChoiceQuestions.Select(question => new QuizQuestionSpecificationData(
                question.OrderNumber,
                question.Text,
                question.Answers.Select(a => a.Data.Text).ToArray())))
            .ToArray();

    public static bool AreQuestionsUnique(IReadOnlyCollection<QuizQuestionSpecificationData> data)
    {
        foreach (var (question, index) in data
                     .SkipLast(1)
                     .Select((question, index) => (question, index)))
        {
            var questionsWithSameText = data
                .Skip(index + 1)
                .Where(d => d.Text.Equals(question.Text));

            if (questionsWithSameText.Any(q => question.Answers.Select(a => a).CollectionEqual(q.Answers.Select(a => a))))
                return false;
        }

        return true;
    }
}