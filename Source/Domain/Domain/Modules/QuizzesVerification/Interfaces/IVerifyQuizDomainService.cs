using Domain.Modules.QuizzesVerification.Data;

namespace Domain.Modules.QuizzesVerification.Interfaces;

public interface IVerifyQuizDomainService
{
    QuizVerificationResultData Verify(QuizVerificationData data);
}