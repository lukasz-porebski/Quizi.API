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
        QuizSingleChoiceQuestionVerificationData givenAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedQuestion(givenAnswer, question);
        var points = verifiedQuestion switch
        {
            QuizSingleChoiceQuestionVerificationResultType.SelectedCorrectAnswer => QuizVerificationConstants.PointsForCorrectAnswer,
            QuizSingleChoiceQuestionVerificationResultType.SelectedWrongAnswer => QuizVerificationConstants.PointsForWrongAnswer,
            _ => QuizVerificationConstants.PointsForNoAnswer
        };

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points,
            PointsPossibleToGet: QuizVerificationConstants.PointsForCorrectAnswer
        );
    }
}