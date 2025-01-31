using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizAddUserSpecification : ISpecification<QuizAddUserSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.UserHasThisQuiz;

    public bool IsValid(QuizAddUserSpecificationData data) =>
        !data.CurrentUsers.Contains(data.NewUser);
}