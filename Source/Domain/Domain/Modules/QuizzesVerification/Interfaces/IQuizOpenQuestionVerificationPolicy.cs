using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Domain.Modules.QuizzesVerification.Interfaces;

public interface IQuizOpenQuestionVerificationPolicy
{
    QuizQuestionVerificationResultData Verify(QuizOpenQuestionVerificationData userAnswer, QuizOpenQuestion question);
}