using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.VerifyQuiz.MethodData.Questions;

namespace Domain.Modules.VerifyQuiz.Specifications.Implementations.QuestionOrderNumber;

internal class VerifiedQuizQuestionOrderNumberIsUniqueSpecification : ISpecification<List<VerifyQuizQuestionData>>
{
    public string FailureMessageCode => VerifyQuizMessages.VerifiedQuestionOrderNumberIsUnique;

    public bool IsValid(List<VerifyQuizQuestionData> data) =>
        !data.Select(q => q.OrderNumber).ContainsDuplicates();
}