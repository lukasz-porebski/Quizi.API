using Common.Domain.Specification;
using Domain.Modules.VerifyQuiz.Specifications.Data;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionAnswerOrderNumber;

internal class VerifiedQuizQuestionAnswerMaximalOrderNumberIsEqualToVerifiedQuestionsCountSpecification
    : ISpecification<VerifiedQuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuestionAnswerMaximalOrderNumberIsEqualToVerifiedQuestionsCount;

    public bool IsValid(VerifiedQuizClosedEndedQuestionSpecificationData data) =>
        data.AllValidatedAnswers.Max(q => q.OrderNumber).Equals(data.AllValidatedAnswers.Count);
}