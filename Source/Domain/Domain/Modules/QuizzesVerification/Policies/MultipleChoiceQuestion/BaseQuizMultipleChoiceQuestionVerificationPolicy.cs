using Domain.Modules.Quizzes.Models;
using Domain.Modules.QuizzesVerification.Data.Sub;

namespace Domain.Modules.QuizzesVerification.Policies.MultipleChoiceQuestion;

public abstract class BaseQuizMultipleChoiceQuestionVerificationPolicy
{
    protected MultipleChoiceQuestionVerificationResultData GetVerifiedQuestion(
        QuizMultipleChoiceQuestionVerificationData userAnswers, QuizMultipleChoiceQuestion question)
    {
        var numberOfCorrectAnswersMarked = userAnswers.SelectedAnswerNos.Count(a =>
            question.GetCorrectAnswers().Any(c => c.SubNo == a));
        return new MultipleChoiceQuestionVerificationResultData(
            numberOfCorrectAnswersMarked,
            NumberOfWrongAnswersMarked: question.Answers.Count - numberOfCorrectAnswersMarked
        );
    }
}