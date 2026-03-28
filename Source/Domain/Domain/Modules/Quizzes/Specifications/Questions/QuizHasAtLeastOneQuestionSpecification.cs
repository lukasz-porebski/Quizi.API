using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications.Sub;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Quizzes.Specifications.Questions;

internal class QuizHasAtLeastOneQuestionSpecification : ISpecification<IReadOnlyCollection<QuizQuestionSpecificationData>>
{
    public string FailureMessageCode => QuizMessageCodes.QuizHasToHasAtLeastOneQuestion;

    public bool IsValid(IReadOnlyCollection<QuizQuestionSpecificationData> data) =>
        data.Any();
}