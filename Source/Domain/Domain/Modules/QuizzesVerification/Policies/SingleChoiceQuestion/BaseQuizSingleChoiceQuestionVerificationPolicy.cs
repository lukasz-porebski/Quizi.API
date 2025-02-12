using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;
using Domain.Modules.QuizzesVerification.Enums;

namespace Domain.Modules.QuizzesVerification.Policies.SingleChoiceQuestion;

public abstract class BaseQuizSingleChoiceQuestionVerificationPolicy
{
    protected QuizSingleChoiceQuestionVerificationResultType GetVerifiedQuestion(
        QuizSingleChoiceQuestionVerificationData givenAnswer, QuizSingleChoiceQuestion question)
    {
        if (givenAnswer.SelectedAnswerNo == null)
            return QuizSingleChoiceQuestionVerificationResultType.NoAnswerSelected;

        return question.GetCorrectAnswer().SubNo == givenAnswer.SelectedAnswerNo
            ? QuizSingleChoiceQuestionVerificationResultType.SelectedCorrectAnswer
            : QuizSingleChoiceQuestionVerificationResultType.SelectedWrongAnswer;
    }
}