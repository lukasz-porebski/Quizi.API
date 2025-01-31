using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Questions;

namespace Domain.Modules.Quizzes.Specifications.Implementations.Questions;

internal class QuizHasAtLeastOneQuestionSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuizHasNotDefinedAnyQuestion;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) => data.Any();
}