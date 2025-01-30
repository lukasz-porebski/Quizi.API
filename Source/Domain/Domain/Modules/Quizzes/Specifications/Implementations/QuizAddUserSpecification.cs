using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizAddUserSpecification : ISpecification<QuizAddUserSpecificationData>
{
    public string FailureMessageCode => QuizMessages.UserHasThisQuiz();

    public bool IsValid(QuizAddUserSpecificationData data) =>
        !data.CurrentUsers.Contains(data.NewUser);
}