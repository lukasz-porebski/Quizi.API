using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Commands.Data;
using Common.Domain.ValueObjects;
using Domain.Modules.QuizResults.Data;
using Domain.Modules.QuizResults.Data.Sub;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data;

namespace Application.Modules.QuizzesVerification.Extensions;

internal static class QuizVerificationResultDataExtensions
{
    public static QuizResultCreateData ToResultData(
        this QuizVerificationResultData source, VerifyQuizCommand command, Quiz quiz, AggregateId userId) =>
        new(
            quiz,
            userId,
            quiz.Title,
            command.QuizRunningPeriod,
            quiz.Settings.Duration,
            quiz.Settings.NegativePoints,
            quiz.Settings.RandomAnswers,
            quiz.Settings.RandomQuestions,
            source.CreateOpenQuestions(command, quiz),
            source.CreateSingleChoiceQuestions(command, quiz),
            source.CreateMultipleChoiceQuestions(command, quiz)
        );

    private static IReadOnlyCollection<QuizResultOpenQuestionCreateData> CreateOpenQuestions(
        this QuizVerificationResultData source, VerifyQuizCommand command, Quiz quiz) =>
        source.OpenQuestions
            .Select(verifiedQuestion =>
            {
                var questionToVerify = command.OpenQuestions.First(e => e.No == verifiedQuestion.EntityNo);
                var quizQuestion = quiz.OpenQuestions.First(e => e.No == verifiedQuestion.EntityNo);

                return new QuizResultOpenQuestionCreateData(
                    questionToVerify.OrdinalNumber,
                    quizQuestion.Text,
                    quizQuestion.Answer,
                    questionToVerify.Answer,
                    verifiedQuestion.ScoredPoints,
                    verifiedQuestion.PointsPossibleToGet,
                    questionToVerify.IsCorrect
                );
            })
            .ToArray();

    private static IReadOnlyCollection<QuizResultSingleChoiceQuestionCreateDate> CreateSingleChoiceQuestions(
        this QuizVerificationResultData source, VerifyQuizCommand command, Quiz quiz) =>
        source.SingleChoiceQuestions
            .Select(verifiedQuestion =>
            {
                var questionToVerify = command.SingleChoiceQuestions.First(e => e.No == verifiedQuestion.EntityNo);
                var quizQuestion = quiz.SingleChoiceQuestions.First(e => e.No == verifiedQuestion.EntityNo);

                var answersToVerify = new List<VerifyQuizClosedQuestionAnswerCommandData>(questionToVerify.UnselectedAnswers);
                if (questionToVerify.SelectedAnswer != null)
                    answersToVerify.Add(questionToVerify.SelectedAnswer);

                return new QuizResultSingleChoiceQuestionCreateDate(
                    questionToVerify.OrdinalNumber,
                    quizQuestion.Text,
                    verifiedQuestion.ScoredPoints,
                    verifiedQuestion.PointsPossibleToGet,
                    answersToVerify
                        .Select(verifiedAnswer =>
                        {
                            var answerToVerify = answersToVerify.First(x => x.No == verifiedAnswer.No);
                            var quizAnswer = quizQuestion.Answers.First(x => x.SubNo == verifiedAnswer.No);

                            return new QuizResultClosedQuestionAnswerCreateData(
                                questionToVerify.OrdinalNumber,
                                quizQuestion.Text,
                                quizAnswer.IsCorrect,
                                answerToVerify.No == questionToVerify.SelectedAnswer?.No
                            );
                        })
                        .ToArray()
                );
            })
            .ToArray();

    private static IReadOnlyCollection<QuizResultMultipleChoiceQuestionCreateDate> CreateMultipleChoiceQuestions(
        this QuizVerificationResultData source, VerifyQuizCommand command, Quiz quiz) =>
        source.MultipleChoiceQuestions
            .Select(verifiedQuestion =>
            {
                var questionToVerify = command.MultipleChoiceQuestions.First(e => e.No == verifiedQuestion.EntityNo);
                var quizQuestion = quiz.MultipleChoiceQuestions.First(e => e.No == verifiedQuestion.EntityNo);

                var answersToVerify = questionToVerify.UnselectedAnswers.Concat(questionToVerify.SelectedAnswers).ToArray();

                return new QuizResultMultipleChoiceQuestionCreateDate(
                    questionToVerify.OrdinalNumber,
                    quizQuestion.Text,
                    verifiedQuestion.ScoredPoints,
                    verifiedQuestion.PointsPossibleToGet,
                    answersToVerify
                        .Select(verifiedAnswer =>
                        {
                            var answerToVerify = answersToVerify.First(x => x.No == verifiedAnswer.No);
                            var quizAnswer = quizQuestion.Answers.First(x => x.SubNo == verifiedAnswer.No);

                            return new QuizResultClosedQuestionAnswerCreateData(
                                questionToVerify.OrdinalNumber,
                                quizQuestion.Text,
                                quizAnswer.IsCorrect,
                                questionToVerify.SelectedAnswers.Any(s => s.No == answerToVerify.No)
                            );
                        })
                        .ToArray()
                );
            })
            .ToArray();
}