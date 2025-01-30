using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionOrderNumber;

internal class QuizQuestionMaximalOrderNumberIsEqualToQuestionsCountSpecification
    : ISpecification<IEnumerable<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessages.QuestionMaximalOrderNumberIsEqualToQuestionsCount();

    public bool IsValid(IEnumerable<QuizQuestionSpecificationData> data) =>
        data.Max(q => q.OrderNumber).Equals(data.Count());
}