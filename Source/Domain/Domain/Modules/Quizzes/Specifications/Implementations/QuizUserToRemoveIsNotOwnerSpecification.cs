using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizUserToRemoveIsNotOwnerSpecification : ISpecification<QuizRemoveUserSpecificationData>
{
    public string FailureMessageCode => QuizMessages.UserToRemoveIsOwner();

    public bool IsValid(QuizRemoveUserSpecificationData data) =>
        !data.OwnerId.Equals(data.IdOfUserToRemove);
}