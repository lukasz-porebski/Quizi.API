using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Constants;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Enums;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Domain.Modules.QuizzesVerification.Policies.SingleChoiceQuestion;

public class QuizSingleChoiceQuestionNegativePointsVerificationPolicy
    : BaseQuizSingleChoiceQuestionVerificationPolicy, IQuizSingleChoiceQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData Verify(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedQuestion(userAnswer, question);
        var points = verifiedQuestion switch
        {
            QuizSingleChoiceQuestionVerificationResultType.MarkedCorrectAnswer => QuizVerificationConstants.PointsForCorrectAnswer,
            QuizSingleChoiceQuestionVerificationResultType.MarkedWrongAnswer => QuizVerificationConstants.PointsForWrongAnswer,
            _ => QuizVerificationConstants.PointsForNoAnswer
        };

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points,
            PointsPossibleToGet: QuizVerificationConstants.PointsForCorrectAnswer
        );
    }
}