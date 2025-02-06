using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Enums;

namespace Domain.Modules.QuizzesVerification.Policies.SingleChoiceQuestion;

public abstract class BaseQuizSingleChoiceQuestionVerificationPolicy
{
    protected QuizSingleChoiceQuestionVerificationResultType GetVerifiedQuestion(
        QuizSingleChoiceQuestionVerificationData userAnswer, QuizSingleChoiceQuestion question)
    {
        if (userAnswer.SelectedAnswerNo == null)
            return QuizSingleChoiceQuestionVerificationResultType.NoAnswerSelected;

        return question.GetCorrectAnswer().SubNo == userAnswer.SelectedAnswerNo
            ? QuizSingleChoiceQuestionVerificationResultType.SelectedCorrectAnswer
            : QuizSingleChoiceQuestionVerificationResultType.SelectedWrongAnswer;
    }
}