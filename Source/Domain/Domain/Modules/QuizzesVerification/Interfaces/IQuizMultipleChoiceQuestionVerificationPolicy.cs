using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Domain.Modules.QuizzesVerification.Interfaces;

public interface IQuizMultipleChoiceQuestionVerificationPolicy
{
    QuizQuestionVerificationResultData Verify(
        QuizMultipleChoiceQuestionVerificationData givenAnswer, QuizMultipleChoiceQuestion question);
}