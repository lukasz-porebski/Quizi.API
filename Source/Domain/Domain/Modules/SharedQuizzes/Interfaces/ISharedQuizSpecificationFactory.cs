using Domain.Modules.SharedQuizzes.Data;
using LP.Common.Domain.Specification;

namespace Domain.Modules.SharedQuizzes.Interfaces;

public interface ISharedQuizSpecificationFactory
{
    SpecificationBuilderDirector AddUser(SharedQuizAddUserSpecificationData data);
    SpecificationBuilderDirector RemoveUser(SharedQuizRemoveUserSpecificationData data);
}