using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Specifications;

internal class QuizUserToRemoveIsNotOwnerSpecification : ISpecification<QuizRemoveUserSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.UserToRemoveIsOwner;

    public bool IsValid(QuizRemoveUserSpecificationData data) =>
        !data.OwnerId.Equals(data.IdOfUserToRemove);
}