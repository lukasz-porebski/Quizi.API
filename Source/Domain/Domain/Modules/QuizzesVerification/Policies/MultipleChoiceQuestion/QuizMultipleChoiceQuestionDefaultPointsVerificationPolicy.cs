using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Constants;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Domain.Modules.QuizzesVerification.Policies.MultipleChoiceQuestion;

public class QuizMultipleChoiceQuestionDefaultPointsVerificationPolicy
    : BaseQuizMultipleChoiceQuestionVerificationPolicy, IQuizMultipleChoiceQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData Verify(
        QuizMultipleChoiceQuestionVerificationData givenAnswer, QuizMultipleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedQuestion(givenAnswer, question);
        var points = verifiedQuestion.NumberOfSelectedCorrectAnswers - verifiedQuestion.NumberOfSelectedWrongAnswers;

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points > 0
                ? (float)points / question.GetCorrectAnswers().Count
                : QuizVerificationConstants.PointsForNoAnswer,
            PointsPossibleToGet: QuizVerificationConstants.PointsForCorrectAnswer
        );
    }
}