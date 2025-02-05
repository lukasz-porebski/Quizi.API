using Common.Shared.Attributes;
using Domain.Modules.QuizzesVerification.Interfaces;
using Domain.Modules.QuizzesVerification.Policies.MultipleChoiceQuestion;
using Domain.Modules.QuizzesVerification.Policies.OpenQuestion;
using Domain.Modules.QuizzesVerification.Policies.SingleChoiceQuestion;

namespace Domain.Modules.QuizzesVerification.Factories;

[Factory]
public class QuizVerificationPolicyFactory : IQuizVerificationPolicyFactory
{
    public IQuizOpenQuestionVerificationPolicy CreateForOpenQuestion(bool negativePoints) =>
        negativePoints
            ? new QuizOpenQuestionNegativePointsVerificationPolicy()
            : new QuizOpenQuestionDefaultPointsVerificationPolicy();

    public IQuizSingleChoiceQuestionVerificationPolicy CreateForSingleChoiceQuestion(bool negativePoints) =>
        negativePoints
            ? new QuizSingleChoiceQuestionNegativePointsVerificationPolicy()
            : new QuizSingleChoiceQuestionDefaultPointsVerificationPolicy();

    public IQuizMultipleChoiceQuestionVerificationPolicy CreateForMultipleChoiceQuestion(bool negativePoints) =>
        negativePoints
            ? new QuizMultipleChoiceQuestionNegativePointsVerificationPolicy()
            : new QuizMultipleChoiceQuestionDefaultPointsVerificationPolicy();
}