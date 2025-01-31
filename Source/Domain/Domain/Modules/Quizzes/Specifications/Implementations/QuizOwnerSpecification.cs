using Common.Domain.Specification;
using Domain.Modules.Quizzes.Constants;
using Domain.Modules.Quizzes.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizOwnerSpecification : ISpecification<IQuizOwnerSpecification>
{
    public string FailureMessageCode => QuizMessageCodes.AccessDenied;

    public bool IsValid(IQuizOwnerSpecification data) =>
        data.OwnerId.Equals(data.UserId);
}