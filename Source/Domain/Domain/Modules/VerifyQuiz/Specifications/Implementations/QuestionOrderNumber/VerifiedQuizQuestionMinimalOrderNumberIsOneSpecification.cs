using Common.Domain.Specification;
using Domain.Modules.VerifyQuiz.MethodData.Questions;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionOrderNumber;

internal class VerifiedQuizQuestionMinimalOrderNumberIsOneSpecification : ISpecification<List<VerifyQuizQuestionData>>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuestionMinimalOrderNumberIsNotOne;

    public bool IsValid(List<VerifyQuizQuestionData> data) =>
        data.Min(q => q.OrderNumber).Equals(1);
}