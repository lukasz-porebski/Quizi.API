using Common.Domain.Specification;
using Domain.Modules.SharedQuizzes.Constants;
using Domain.Modules.SharedQuizzes.Data;

namespace Domain.Modules.SharedQuizzes.Specifications;

internal class SharedQuizRemoveUserSpecification : ISpecification<SharedQuizRemoveUserSpecificationData>
{
    public string FailureMessageCode => SharedQuizMessageCodes.UserNotHasThisQuiz;

    public bool IsValid(SharedQuizRemoveUserSpecificationData data) =>
        data.CurrentUserIds.Contains(data.IdOfUserToRemove);
}