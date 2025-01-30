using Common.Domain.Specification;
using Domain.Modules.Quizzes.Specifications.Data;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizRemoveUserSpecification : ISpecification<QuizRemoveUserSpecificationData>
{
    public string FailureMessageCode => QuizMessages.UserNotHasThisQuiz();

    public bool IsValid(QuizRemoveUserSpecificationData data) =>
        data.CurrentUsersIds.Contains(data.IdOfUserToRemove);
}