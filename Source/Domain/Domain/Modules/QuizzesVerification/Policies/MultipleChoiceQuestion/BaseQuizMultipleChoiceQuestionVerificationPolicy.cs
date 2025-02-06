using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Domain.Modules.QuizzesVerification.Policies.MultipleChoiceQuestion;

public abstract class BaseQuizMultipleChoiceQuestionVerificationPolicy
{
    protected MultipleChoiceQuestionVerificationResultData GetVerifiedQuestion(
        QuizMultipleChoiceQuestionVerificationData userAnswers, QuizMultipleChoiceQuestion question)
    {
        var numberOfSelectedCorrectAnswers = userAnswers.SelectedAnswerNos.Count(a =>
            question.GetCorrectAnswers().Any(c => c.SubNo == a));
        return new MultipleChoiceQuestionVerificationResultData(
            numberOfSelectedCorrectAnswers,
            NumberOfSelectedWrongAnswers: question.Answers.Count - numberOfSelectedCorrectAnswers
        );
    }
}