using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Enums;
using Domain.Modules.Quizzes.Models;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizSpecificationHelper
{
    internal static IReadOnlyCollection<QuizClosedQuestionSpecificationData> GetClosedEndedQuestions(
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions) =>
        singleChoiceQuestions
            .Select(question => new QuizClosedQuestionSpecificationData(
                QuizClosedQuestionType.SingleChoice, question.Text, question.Answers))
            .Concat(multipleChoiceQuestions.Select(question => new QuizClosedQuestionSpecificationData(
                QuizClosedQuestionType.MultipleChoice, question.Text, question.Answers)))
            .ToArray();

    internal static IReadOnlyCollection<QuizQuestionSpecificationData> GetQuestions(
        IReadOnlyCollection<QuizOpenQuestion> oldOpenQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestion> oldMultipleChoiceQuestions)
    {
        var openQuestions = oldOpenQuestions
            .Select(q => new QuizOpenQuestionSpecificationData(
                OrderNumber: q.OrderNumber,
                Text: q.Text,
                CorrectAnswer: q.CorrectAnswer))
            .ToArray();

        var singleChoiceQuestions = oldSingleChoiceQuestions
            .Select(q => new QuizSingleChoiceQuestionSpecificationData(
                OrderNumber: q.OrderNumber,
                Text: q.Text,
                Answers: q.Answers.ToList()))
            .ToArray();

        var multipleChoiceQuestions = oldMultipleChoiceQuestions
            .Select(q => new QuizMultipleChoiceQuestionSpecificationData(
                q.OrderNumber,
                q.Text,
                q.Answers))
            .ToArray();

        return GetQuestions(openQuestions, singleChoiceQuestions, multipleChoiceQuestions);
    }

    internal static IReadOnlyCollection<QuizQuestionSpecificationData> GetQuestions(
        IReadOnlyCollection<QuizOpenQuestionSpecificationData> openQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions) =>
        openQuestions
            .Select(question => new QuizQuestionSpecificationData(
                question.OrderNumber,
                question.Text,
                new List<string> { question.CorrectAnswer }))
            .Concat(singleChoiceQuestions.Select(question => new QuizQuestionSpecificationData(
                question.OrderNumber,
                question.Text,
                question.Answers.Select(a => a.Text).ToArray())))
            .Concat(multipleChoiceQuestions.Select(question => new QuizQuestionSpecificationData(
                question.OrderNumber,
                question.Text,
                question.Answers.Select(a => a.Text).ToArray())))
            .ToArray();

    internal static bool AreQuestionsUnique(IReadOnlyCollection<QuizQuestionSpecificationData> data)
    {
        foreach (var (question, index) in data
                     .SkipLast(1)
                     .Select((question, index) => (question, index)))
        {
            var questionsWithSameText = data
                .Skip(index + 1)
                .Where(d => d.Text.Equals(question.Text));

            if (questionsWithSameText.Any(q =>
                    AreAnswersTheSame(
                        question.Answers.Select(a => a),
                        q.Answers.Select(a => a))))
                return false;
        }

        return true;
    }

    private static bool AreAnswersTheSame(IEnumerable<string> one, IEnumerable<string> two) => one.CollectionEqual(two);
}