using Common.Domain.Specification;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionOrderNumber;

internal class QuizQuestionMinimalOrderNumberIsOneSpecification : ISpecification<IEnumerable<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessages.QuestionMinimalOrderNumberIsNotOne();

    public bool IsValid(IEnumerable<QuizQuestionSpecificationData> data) =>
        data.Min(q => q.OrderNumber).Equals(1);
}