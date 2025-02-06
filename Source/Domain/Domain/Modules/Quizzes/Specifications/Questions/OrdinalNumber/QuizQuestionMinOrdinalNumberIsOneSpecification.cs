using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;

namespace Domain.Modules.Quizzes.Specifications.Questions.OrdinalNumber;

internal class QuizQuestionMinOrdinalNumberIsOneSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionMinimalOrdinalNumberIsNotOne;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        data.Min(q => q.OrdinalNumber).Equals(1);
}