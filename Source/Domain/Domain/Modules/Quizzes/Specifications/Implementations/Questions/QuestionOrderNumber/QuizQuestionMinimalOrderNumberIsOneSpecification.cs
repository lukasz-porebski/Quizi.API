using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionOrderNumber;

internal class QuizQuestionMinimalOrderNumberIsOneSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuestionMinimalOrderNumberIsNotOne;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        data.Min(q => q.OrderNumber).Equals(1);
}