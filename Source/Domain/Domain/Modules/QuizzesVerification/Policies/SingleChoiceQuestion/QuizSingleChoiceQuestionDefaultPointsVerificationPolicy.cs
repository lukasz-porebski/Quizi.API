using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Constants;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Enums;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Domain.Modules.QuizzesVerification.Policies.SingleChoiceQuestion;

public class QuizSingleChoiceQuestionDefaultPointsVerificationPolicy
    : BaseQuizSingleChoiceQuestionVerificationPolicy, IQuizSingleChoiceQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData Verify(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedQuestion(userAnswer, question);

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: verifiedQuestion == QuizSingleChoiceQuestionVerificationResultType.MarkedCorrectAnswer
                ? QuizVerificationConstants.PointsForCorrectAnswer
                : QuizVerificationConstants.PointsForNoAnswer,
            PointsPossibleToGet: QuizVerificationConstants.PointsForCorrectAnswer
        );
    }
}