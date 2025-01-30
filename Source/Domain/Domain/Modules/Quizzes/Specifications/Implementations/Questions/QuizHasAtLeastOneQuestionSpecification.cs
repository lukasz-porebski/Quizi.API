using Common.Domain.Specification;
using Domain.Modules.Quizzes.Specifications.Data.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizHasAtLeastOneQuestionSpecification : ISpecification<IEnumerable<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessages.QuizHasNotDefinedAnyQuestion();

    public bool IsValid(IEnumerable<QuizQuestionSpecificationData> data) => data.Any();
}