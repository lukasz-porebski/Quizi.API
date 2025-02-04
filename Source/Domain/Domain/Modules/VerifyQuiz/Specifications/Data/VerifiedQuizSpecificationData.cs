using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.Enums;
using Domain.Modules.VerifyQuiz.MethodData.Questions;
using Domain.Modules.VerifyQuiz.ValueObjects;

namespace Domain.Modules.VerifyQuiz.Specifications.Data;

internal class VerifiedQuizSpecificationData
{
    internal List<QuizOpenQuestion> OpenEndedQuestions { get; }
    internal List<QuizSingleChoiceQuestion> SingleChoiceQuestions { get; }
    internal List<QuizMultipleChoiceQuestion> MultipleChoiceQuestions { get; }

    internal List<VerifyQuizOpenEndedQuestionData> VerifiedOpenEndedQuestions { get; }
    internal List<VerifyQuizSingleChoiceQuestionData> VerifiedSingleChoiceQuestions { get; }
    internal List<VerifyQuizMultipleChoiceQuestionData> VerifiedMultipleChoiceQuestions { get; }

    internal List<VerifiedQuizClosedEndedQuestionSpecificationData> ClosedEndedQuestions { get; }
    internal List<VerifyQuizQuestionData> VerifyQuizQuestions { get; }

    internal VerifiedQuizSpecificationData(
        IEnumerable<QuizOpenQuestion> openEndedQuestions,
        IEnumerable<QuizSingleChoiceQuestion> singleChoiceQuestions,
        IEnumerable<QuizMultipleChoiceQuestion> multipleChoiceQuestions,
        IEnumerable<VerifyQuizOpenEndedQuestionData> verifiedOpenEndedQuestions,
        IEnumerable<VerifyQuizSingleChoiceQuestionData> verifiedSingleChoiceQuestions,
        IEnumerable<VerifyQuizMultipleChoiceQuestionData> verifiedMultipleChoiceQuestions)
    {
        OpenEndedQuestions = openEndedQuestions.ToList();
        SingleChoiceQuestions = singleChoiceQuestions.ToList();
        MultipleChoiceQuestions = multipleChoiceQuestions.ToList();
        VerifiedOpenEndedQuestions = verifiedOpenEndedQuestions.ToList();
        VerifiedSingleChoiceQuestions = verifiedSingleChoiceQuestions.ToList();
        VerifiedMultipleChoiceQuestions = verifiedMultipleChoiceQuestions.ToList();
        ClosedEndedQuestions = GetClosedEndedQuestions(
            SingleChoiceQuestions, MultipleChoiceQuestions,
            VerifiedSingleChoiceQuestions, VerifiedMultipleChoiceQuestions);
        VerifyQuizQuestions = GetVerifyQuizQuestions(
            VerifiedOpenEndedQuestions, VerifiedSingleChoiceQuestions, VerifiedMultipleChoiceQuestions);
    }

    private static List<VerifiedQuizClosedEndedQuestionSpecificationData> GetClosedEndedQuestions(
        IReadOnlyList<QuizSingleChoiceQuestion> singleChoiceQuestions,
        IReadOnlyList<QuizMultipleChoiceQuestion> multipleChoiceQuestions,
        IEnumerable<VerifyQuizSingleChoiceQuestionData> verifiedSingleChoiceQuestions,
        IEnumerable<VerifyQuizMultipleChoiceQuestionData> verifiedMultipleChoiceQuestions)
    {
        var result = new List<VerifiedQuizClosedEndedQuestionSpecificationData>();

        foreach (var question in verifiedSingleChoiceQuestions)
        {
            var validatedAnswers = new List<IQuizQuestionAnswer>();

            if (question.SelectedAnswer.HasValue)
                validatedAnswers.Add(question.SelectedAnswer.Value);

            validatedAnswers.AddRange(question.UnselectedAnswers.Select(a => a as IQuizQuestionAnswer));

            var quizQuestion = singleChoiceQuestions.SingleOrDefault(q => q.No.Equals(question.No));

            var quizQuestionAnswers = new List<IQuizQuestionAnswer>();

            if (quizQuestion != null)
            {
                quizQuestionAnswers.Add(quizQuestion.GetCorrectAnswer());
                quizQuestionAnswers.AddRange(quizQuestion.GetWrongAnswers());
            }

            result.Add(new VerifiedQuizClosedEndedQuestionSpecificationData(
                Type: QuizClosedEndedQuestionType.SingleChoice,
                AllValidatedAnswers: validatedAnswers,
                QuizQuestionAnswers: quizQuestionAnswers));
        }

        foreach (var question in verifiedMultipleChoiceQuestions)
        {
            var answers = new List<IQuizQuestionAnswer>();
            answers.AddRange(question.SelectedAnswers.Select(a => a as IQuizQuestionAnswer));
            answers.AddRange(question.UnselectedAnswers.Select(a => a as IQuizQuestionAnswer));

            var quizQuestion = multipleChoiceQuestions.SingleOrDefault(q => q.No.Equals(question.No));

            var quizQuestionAnswers = new List<IQuizQuestionAnswer>();

            if (quizQuestion != null)
            {
                quizQuestionAnswers.AddRange(quizQuestion.GetCorrectAnswers());
                quizQuestionAnswers.AddRange(quizQuestion.GetWrongAnswers());
            }

            result.Add(new VerifiedQuizClosedEndedQuestionSpecificationData(
                Type: QuizClosedEndedQuestionType.MultipleChoice,
                AllValidatedAnswers: answers,
                QuizQuestionAnswers: quizQuestionAnswers));
        }

        return result;
    }

    private static List<VerifyQuizQuestionData> GetVerifyQuizQuestions(
        IEnumerable<VerifyQuizOpenEndedQuestionData> verifiedOpenEndedQuestions,
        IEnumerable<VerifyQuizSingleChoiceQuestionData> verifiedSingleChoiceQuestions,
        IEnumerable<VerifyQuizMultipleChoiceQuestionData> verifiedMultipleChoiceQuestions)
    {
        var result = new List<VerifyQuizQuestionData>();

        result.AddRange(verifiedOpenEndedQuestions);
        result.AddRange(verifiedSingleChoiceQuestions);
        result.AddRange(verifiedMultipleChoiceQuestions);

        return result;
    }
}