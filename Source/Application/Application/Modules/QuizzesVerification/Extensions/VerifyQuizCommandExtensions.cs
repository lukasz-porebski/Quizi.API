using Application.Contracts.Modules.QuizzesVerification.Commands;
using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data;
using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Application.Modules.QuizzesVerification.Extensions;

internal static class VerifyQuizCommandExtensions
{
    public static QuizVerificationData ToVerificationData(this VerifyQuizCommand command, Quiz quiz) =>
        new(
            quiz,
            command.OpenQuestions
                .Select(o => new QuizOpenQuestionVerificationData(o.No, o.IsCorrect))
                .ToArray(),
            command.SingleChoiceQuestions
                .Select(o => new QuizSingleChoiceQuestionVerificationData(o.No, o.SelectedAnswer?.No))
                .ToArray(),
            command.MultipleChoiceQuestions
                .Select(o => new QuizMultipleChoiceQuestionVerificationData(o.No, o.SelectedAnswers.Select(a => a.No).ToArray()))
                .ToArray()
        );
}