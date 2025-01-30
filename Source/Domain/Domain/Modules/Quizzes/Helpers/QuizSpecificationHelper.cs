using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Data.Specifications.Questions;
using Domain.Modules.Quizzes.Enums;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizSpecificationHelper
{
    internal static IReadOnlyCollection<QuizClosedEndedQuestionSpecificationData> GetClosedEndedQuestions(
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions)
    {
        var result = new List<QuizClosedEndedQuestionSpecificationData>();

        foreach (var question in singleChoiceQuestions)
        {
            var answers = new List<QuizQuestionOrderedAnswer> { question.CorrectAnswer };
            answers.AddRange(question.WrongAnswers);

            result.Add(new QuizClosedEndedQuestionSpecificationData(
                QuizClosedEndedQuestionType.SingleChoice, question.Text, answers));
        }

        foreach (var question in multipleChoiceQuestions)
        {
            var answers = new List<QuizQuestionOrderedAnswer>();
            answers.AddRange(question.CorrectAnswers);
            answers.AddRange(question.WrongAnswers);

            result.Add(new QuizClosedEndedQuestionSpecificationData(
                QuizClosedEndedQuestionType.MultipleChoice, question.Text, answers));
        }

        return result;
    }

    internal static IReadOnlyCollection<QuizQuestionSpecificationData> GetQuestions(
        IReadOnlyCollection<OpenEndedQuestion> oldOpenEndedQuestions,
        IReadOnlyCollection<SingleChoiceQuestion> oldSingleChoiceQuestions,
        IReadOnlyCollection<MultipleChoiceQuestion> oldMultipleChoiceQuestions)
    {
        var openEndedQuestions = oldOpenEndedQuestions
            .Select(q => new QuizOpenEndedQuestionSpecificationData(
                OrderNumber: q.OrderNumber,
                Text: q.Text,
                CorrectAnswer: q.CorrectAnswer))
            .ToArray();

        var singleChoiceQuestions = oldSingleChoiceQuestions
            .Select(q => new QuizSingleChoiceQuestionSpecificationData(
                OrderNumber: q.OrderNumber,
                Text: q.Text,
                CorrectAnswer: q.CorrectAnswer,
                WrongAnswers: q.WrongAnswers.ToList()))
            .ToArray();

        var multipleChoiceQuestions = oldMultipleChoiceQuestions
            .Select(q => new QuizMultipleChoiceQuestionSpecificationData(
                q.OrderNumber,
                q.Text,
                q.CorrectAnswers,
                q.WrongAnswers))
            .ToArray();

        return GetQuestions(openEndedQuestions, singleChoiceQuestions, multipleChoiceQuestions);
    }

    internal static IReadOnlyCollection<QuizQuestionSpecificationData> GetQuestions(
        IReadOnlyCollection<QuizOpenEndedQuestionSpecificationData> openEndedQuestions,
        IReadOnlyCollection<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IReadOnlyCollection<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions)
    {
        var result = openEndedQuestions
            .Select(question => new QuizQuestionSpecificationData(
                OrderNumber: question.OrderNumber,
                Text: question.Text,
                Answers: new List<string>
                {
                    question.CorrectAnswer
                }))
            .ToList();

        foreach (var question in singleChoiceQuestions)
        {
            var answers = new List<QuizQuestionOrderedAnswer> { question.CorrectAnswer };
            answers.AddRange(question.WrongAnswers);

            result.Add(new QuizQuestionSpecificationData(
                OrderNumber: question.OrderNumber,
                Text: question.Text,
                Answers: answers.Select(a => a.Text).ToArray()));
        }

        foreach (var question in multipleChoiceQuestions)
        {
            var answers = new List<QuizQuestionOrderedAnswer>();
            answers.AddRange(question.CorrectAnswers);
            answers.AddRange(question.WrongAnswers);

            result.Add(new QuizQuestionSpecificationData(
                OrderNumber: question.OrderNumber,
                Text: question.Text,
                Answers: answers.Select(a => a.Text).ToArray()));
        }

        return result;
    }

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