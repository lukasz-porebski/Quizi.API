using Domain.Modules.VerifyQuiz.MethodData;

namespace Domain.Modules.VerifyQuiz;

public interface IVerifyQuizDomainService
{
    Task VerifyQuiz(VerifyQuizData data);
}