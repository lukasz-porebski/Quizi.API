using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.MethodData;
using Domain.Modules.VerifyQuiz.MethodData.Sub;

namespace Domain.Modules.VerifyQuiz.Policies.Core;

internal interface IQuestionVerificationPolicy
{
    QuizQuestionVerificationResultData VerifyOpenEndedQuestion(
        QuizOpenQuestionVerificationData userAnswer, QuizOpenQuestion question);

    QuizQuestionVerificationResultData VerifySingleChoiceQuestion(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question);

    QuizQuestionVerificationResultData VerifyMultipleChoiceQuestion(
        QuizMultipleChoiceQuestionVerificationData userAnswers, QuizMultipleChoiceQuestion question);
}