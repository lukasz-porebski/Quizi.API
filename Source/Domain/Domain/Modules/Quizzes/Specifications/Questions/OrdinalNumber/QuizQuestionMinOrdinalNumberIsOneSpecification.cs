using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;

internal class QuizQuestionMinOrdinalNumberIsOneSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionMinOrdinalNumberHasToBeOne;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        data.Min(q => q.OrdinalNumber).Equals(1);
}