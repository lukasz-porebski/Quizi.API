using Domain.Modules.Quizzes.Models;
using Domain.Modules.VerifyQuiz.Enums;
using Domain.Modules.VerifyQuiz.MethodData;
using Domain.Modules.VerifyQuiz.MethodData.Sub;
using Domain.Modules.VerifyQuiz.Policies.Core;

namespace Domain.Modules.VerifyQuiz.Policies;

internal class NegativePointsQuestionVerificationPolicy : QuestionVerificationBase, IQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData VerifyOpenEndedQuestion(
        QuizOpenQuestionVerificationData userAnswer, QuizOpenQuestion question)
    {
        var points = 0;
        if (userAnswer.IsCorrect.HasValue)
            points = userAnswer.IsCorrect.Value ? 1 : -1;

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points,
            PointsPossibleToGet: 1);
    }

    public QuizQuestionVerificationResultData VerifySingleChoiceQuestion(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedSingleChoiceQuestion(userAnswer, question);
        var points = verifiedQuestion switch
        {
            SingleChoiceQuestionVerificationResultType.MarkedCorrectAnswer => 1,
            SingleChoiceQuestionVerificationResultType.MarkedWrongAnswer => -1,
            _ => 0
        };

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points,
            PointsPossibleToGet: 1);
    }

    public QuizQuestionVerificationResultData VerifyMultipleChoiceQuestion(
        QuizMultipleChoiceQuestionVerificationData userAnswers, QuizMultipleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedMultipleChoiceQuestion(userAnswers, question);
        var points = verifiedQuestion.NumberOfCorrectAnswersMarked - verifiedQuestion.NumberOfWrongAnswersMarked;

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points,
            PointsPossibleToGet: question.GetCorrectAnswers().Count);
    }
}