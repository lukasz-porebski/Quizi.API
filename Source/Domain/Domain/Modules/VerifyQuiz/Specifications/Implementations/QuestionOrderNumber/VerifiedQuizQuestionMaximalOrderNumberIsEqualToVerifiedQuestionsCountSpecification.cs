using Common.Domain.Specification;
using Domain.Modules.VerifyQuiz.MethodData.Questions;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionOrderNumber;

internal class VerifiedQuizQuestionMaximalOrderNumberIsEqualToVerifiedQuestionsCountSpecification
    : ISpecification<List<VerifyQuizQuestionData>>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuestionMaximalOrderNumberIsEqualToVerifiedQuestionsCount;

    public bool IsValid(List<VerifyQuizQuestionData> data) =>
        data.Max(q => q.OrderNumber).Equals(data.Count);
}