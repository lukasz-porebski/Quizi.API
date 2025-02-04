using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.VerifyQuiz.Specifications.Data;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionAnswerOrderNumber;

internal class VerifiedQuizQuestionAnswerOrderNumberIsUniqueSpecification
    : ISpecification<VerifiedQuizClosedEndedQuestionSpecificationData>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuestionAnswerOrderNumberIsUnique;

    public bool IsValid(VerifiedQuizClosedEndedQuestionSpecificationData data) =>
        !data.AllValidatedAnswers
            .Select(q => q.OrderNumber)
            .ContainsDuplicates();
}