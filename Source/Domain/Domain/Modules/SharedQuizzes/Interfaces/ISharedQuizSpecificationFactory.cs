using Common.Domain.Specification;
using Domain.Modules.Quizzes.Data.Specifications;

namespace Domain.Modules.SharedQuizzes.Interfaces;

public interface ISharedQuizSpecificationFactory
{
    SpecificationBuilderDirector AddUser(SharedQuizAddUserSpecificationData data);
    SpecificationBuilderDirector RemoveUser(SharedQuizRemoveUserSpecificationData data);
}