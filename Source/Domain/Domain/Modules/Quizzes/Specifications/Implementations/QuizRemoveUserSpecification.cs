using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizRemoveUserSpecification : ISpecification<QuizRemoveUserSpecificationData>
{
    public string FailureMessageCode => QuizMessageCodes.UserNotHasThisQuiz;

    public bool IsValid(QuizRemoveUserSpecificationData data) =>
        data.CurrentUserIds.Contains(data.IdOfUserToRemove);
}