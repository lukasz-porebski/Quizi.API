using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.SharedQuizzes.Constants;

namespace Domain.Modules.SharedQuizzes.Specifications;

internal class SharedQuizAddUserSpecification : ISpecification<SharedQuizAddUserSpecificationData>
{
    public string FailureMessageCode => SharedQuizMessageCodes.UserHasThisQuiz;

    public bool IsValid(SharedQuizAddUserSpecificationData data) =>
        !data.CurrentUsers.Contains(data.NewUser);
}