using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;
using Domain.Modules.SharedQuizzes.Constants;

namespace Domain.Modules.SharedQuizzes.Specifications;

internal class SharedQuizRemoveUserSpecification : ISpecification<SharedQuizRemoveUserSpecificationData>
{
    public string FailureMessageCode => SharedQuizMessageCodes.UserNotHasThisQuiz;

    public bool IsValid(SharedQuizRemoveUserSpecificationData data) =>
        data.CurrentUserIds.Contains(data.IdOfUserToRemove);
}