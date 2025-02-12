using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Constants;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Domain.Modules.QuizzesVerification.Policies.OpenQuestion;

public class QuizOpenQuestionNegativePointsVerificationPolicy : IQuizOpenQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData Verify(QuizOpenQuestionVerificationData givenAnswer, QuizOpenQuestion question)
    {
        var points = QuizVerificationConstants.PointsForNoAnswer;
        if (givenAnswer.IsCorrect.HasValue)
            points = givenAnswer.IsCorrect.Value
                ? QuizVerificationConstants.PointsForCorrectAnswer
                : QuizVerificationConstants.PointsForWrongAnswer;

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points,
            PointsPossibleToGet: QuizVerificationConstants.PointsForCorrectAnswer
        );
    }
}