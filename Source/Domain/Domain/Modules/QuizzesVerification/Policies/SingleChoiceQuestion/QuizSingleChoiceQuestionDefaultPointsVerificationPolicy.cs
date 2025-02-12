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
        QuizSingleChoiceQuestionVerificationData givenAnswer, QuizSingleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedQuestion(givenAnswer, question);

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: verifiedQuestion == QuizSingleChoiceQuestionVerificationResultType.SelectedCorrectAnswer
                ? QuizVerificationConstants.PointsForCorrectAnswer
                : QuizVerificationConstants.PointsForNoAnswer,
            PointsPossibleToGet: QuizVerificationConstants.PointsForCorrectAnswer
        );
    }
}