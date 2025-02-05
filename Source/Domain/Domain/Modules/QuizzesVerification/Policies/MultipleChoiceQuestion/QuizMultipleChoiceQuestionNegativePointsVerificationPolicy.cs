using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Interfaces;

namespace Domain.Modules.QuizzesVerification.Policies.MultipleChoiceQuestion;

public class QuizMultipleChoiceQuestionNegativePointsVerificationPolicy
    : BaseQuizMultipleChoiceQuestionVerificationPolicy, IQuizMultipleChoiceQuestionVerificationPolicy
{
    public QuizQuestionVerificationResultData Verify(
        QuizMultipleChoiceQuestionVerificationData userAnswer, QuizMultipleChoiceQuestion question)
    {
        var verifiedQuestion = GetVerifiedQuestion(userAnswer, question);
        var points = verifiedQuestion.NumberOfCorrectAnswersMarked - verifiedQuestion.NumberOfWrongAnswersMarked;

        return new QuizQuestionVerificationResultData(
            question.No,
            ScoredPoints: points,
            PointsPossibleToGet: question.GetCorrectAnswers().Count
        );
    }
}