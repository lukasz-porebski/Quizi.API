using Common.Domain.Specification;
using Common.Shared.Extensions;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions.QuestionOrderNumber;

internal class QuizQuestionOrderNumberIsUniqueSpecification : ISpecification<IEnumerable<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessages.QuestionOrderNumberIsUnique();

    public bool IsValid(IEnumerable<QuizQuestionSpecificationData> data) =>
        !data.Select(q => q.OrderNumber)
            .ContainsDuplicates();
}