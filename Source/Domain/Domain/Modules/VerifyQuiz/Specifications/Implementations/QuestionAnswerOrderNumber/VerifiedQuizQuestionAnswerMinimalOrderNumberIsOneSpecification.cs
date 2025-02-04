using Common.Domain.Specification;
using Domain.Modules.VerifyQuiz.Specifications.Data;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionAnswerOrderNumber;

internal class VerifiedQuizQuestionAnswerMinimalOrderNumberIsOneSpecification
    : ISpecification<VerifiedQuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuestionAnswerMinimalOrderNumberIsNotOne;

    public bool IsValid(VerifiedQuizClosedEndedQuestionSpecificationData data) =>
        data.AllValidatedAnswers.Min(q => q.OrderNumber).Equals(1);
}