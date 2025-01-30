using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Enums;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.Quizzes.Specifications.Data.Questions;
using Domain.Modules.Quizzes.ValueObjects;

namespace Domain.Modules.Quizzes.Helpers;

internal static class QuizSpecificationHelper
{
    internal static IEnumerable<QuizClosedEndedQuestionSpecificationData> GetClosedEndedQuestions(
        IEnumerable<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions)
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

    internal static IEnumerable<QuizQuestionSpecificationData> GetQuestions(
        IEnumerable<OpenEndedQuestionEntity> oldOpenEndedQuestions,
        IEnumerable<SingleChoiceQuestionEntity> oldSingleChoiceQuestions,
        IEnumerable<MultipleChoiceQuestionEntity> oldMultipleChoiceQuestions)
    {
        var openEndedQuestions = oldOpenEndedQuestions.Select(q =>
            new QuizOpenEndedQuestionSpecificationData(
                orderNumber: q.OrderNumber,
                text: q.Text,
                correctAnswer: q.CorrectAnswer));

        var singleChoiceQuestions = oldSingleChoiceQuestions.Select(q =>
            new QuizSingleChoiceQuestionSpecificationData(
                orderNumber: q.OrderNumber,
                text: q.Text,
                correctAnswer: q.CorrectAnswer,
                wrongAnswers: q.WrongAnswers.ToList()));

        var multipleChoiceQuestions = oldMultipleChoiceQuestions.Select(q =>
            new QuizMultipleChoiceQuestionSpecificationData(
                orderNumber: q.OrderNumber,
                text: q.Text,
                correctAnswers: q.CorrectAnswers.ToList(),
                wrongAnswers: q.WrongAnswers.ToList()));

        return GetQuestions(openEndedQuestions, singleChoiceQuestions, multipleChoiceQuestions);
    }

    internal static IEnumerable<QuizQuestionSpecificationData> GetQuestions(
        IEnumerable<QuizOpenEndedQuestionSpecificationData> openEndedQuestions,
        IEnumerable<QuizSingleChoiceQuestionSpecificationData> singleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestionSpecificationData> multipleChoiceQuestions)
    {
        var result = openEndedQuestions
            .Select(question => new QuizQuestionSpecificationData(
                orderNumber: question.OrderNumber,
                text: question.Text,
                answers: new List<string>
                {
                    question.CorrectAnswer
                }))
            .ToList();

        foreach (var question in singleChoiceQuestions)
        {
            var answers = new List<QuizQuestionOrderedAnswer> { question.CorrectAnswer };
            answers.AddRange(question.WrongAnswers);

            result.Add(new QuizQuestionSpecificationData(
                orderNumber: question.OrderNumber,
                text: question.Text,
                answers: answers.Select(a => a.Text)));
        }

        foreach (var question in multipleChoiceQuestions)
        {
            var answers = new List<QuizQuestionOrderedAnswer>();
            answers.AddRange(question.CorrectAnswers);
            answers.AddRange(question.WrongAnswers);

            result.Add(new QuizQuestionSpecificationData(
                orderNumber: question.OrderNumber,
                text: question.Text,
                answers: answers.Select(a => a.Text)));
        }

        return result;
    }

    internal static bool AreQuestionsUnique(IEnumerable<QuizQuestionSpecificationData> data)
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