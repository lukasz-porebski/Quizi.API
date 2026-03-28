using Domain.Modules.SharedQuizzes.Constants;
using Domain.Modules.SharedQuizzes.Data;
using LP.Common.Domain.Specification;

namespace Domain.Modules.SharedQuizzes.Specifications;

internal class SharedQuizRemoveUserSpecification : ISpecification<SharedQuizRemoveUserSpecificationData>
{
    public string FailureMessageCode => SharedQuizMessageCodes.UserNotHasThisQuiz;

    public bool IsValid(SharedQuizRemoveUserSpecificationData data) =>
        data.CurrentUserIds.Contains(data.IdOfUserToRemove);
}