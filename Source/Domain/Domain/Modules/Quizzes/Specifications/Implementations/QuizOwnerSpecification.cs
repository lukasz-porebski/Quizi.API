using Common.Domain.Specification;
using Domain.Modules.Quizzes.Specifications.Interfaces;

namespace Domain.Modules.Quizzes.Specifications.Implementations;

internal class QuizOwnerSpecification : ISpecification<IQuizOwnerSpecification>
{
    public string FailureMessageCode => QuizMessages.AccessDenied();

    public bool IsValid(IQuizOwnerSpecification data) =>
        data.OwnerId.Equals(data.UserId);
}