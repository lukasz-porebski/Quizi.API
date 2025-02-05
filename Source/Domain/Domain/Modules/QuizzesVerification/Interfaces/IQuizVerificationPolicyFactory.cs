namespace Domain.Modules.QuizzesVerification.Interfaces;

public interface IQuizVerificationPolicyFactory
{
    IQuizOpenQuestionVerificationPolicy CreateForOpenQuestion(bool negativePoints);
    IQuizSingleChoiceQuestionVerificationPolicy CreateForSingleChoiceQuestion(bool negativePoints);
    IQuizMultipleChoiceQuestionVerificationPolicy CreateForMultipleChoiceQuestion(bool negativePoints);
}