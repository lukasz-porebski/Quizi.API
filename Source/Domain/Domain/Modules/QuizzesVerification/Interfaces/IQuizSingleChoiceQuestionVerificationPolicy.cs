using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Domain.Modules.QuizzesVerification.Interfaces;

public interface IQuizSingleChoiceQuestionVerificationPolicy
{
    QuizQuestionVerificationResultData Verify(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question);
}