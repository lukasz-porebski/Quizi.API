using Common.Domain.Specification;
using Domain.Modules.SharedQuizzes.Constants;
using Domain.Modules.SharedQuizzes.Data;

namespace Domain.Modules.SharedQuizzes.Specifications;

internal class SharedQuizAddUserSpecification : ISpecification<SharedQuizAddUserSpecificationData>
{
    public string FailureMessageCode => SharedQuizMessageCodes.UserHasThisQuiz;

    public bool IsValid(SharedQuizAddUserSpecificationData data) =>
        !data.CurrentUsers.Contains(data.NewUserId);
}