using Domain.Modules.Users.Data;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Users.Interfaces;

public interface IUserSpecificationFactory
{
    SpecificationBuilderDirector CreateForCreation(UserCreationData data);
}