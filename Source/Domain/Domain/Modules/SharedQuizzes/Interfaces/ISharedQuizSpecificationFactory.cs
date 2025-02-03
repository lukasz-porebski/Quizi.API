using Common.Domain.Specification;
using Domain.Modules.SharedQuizzes.Data;

namespace Domain.Modules.SharedQuizzes.Interfaces;

public interface ISharedQuizSpecificationFactory
{
    SpecificationBuilderDirector AddUser(SharedQuizAddUserSpecificationData data);
    SpecificationBuilderDirector RemoveUser(SharedQuizRemoveUserSpecificationData data);
}