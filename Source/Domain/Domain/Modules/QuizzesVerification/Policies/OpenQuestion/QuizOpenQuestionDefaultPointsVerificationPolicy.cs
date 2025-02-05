using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Constants;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Domain.Modules.QuizzesVerification.Policies.OpenQuestion;

public class QuizOpenQuestionDefaultPointsVerificationPolicy : IQuizOpenQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData Verify(QuizOpenQuestionVerificationData userAnswer, QuizOpenQuestion question) =>
        new(question.No,
            ScoredPoints: userAnswer.IsCorrect.HasValue && userAnswer.IsCorrect.Value
                ? QuizVerificationConstants.PointsForCorrectAnswer
                : QuizVerificationConstants.PointsForNoAnswer,
            PointsPossibleToGet: QuizVerificationConstants.PointsForCorrectAnswer
        );
}