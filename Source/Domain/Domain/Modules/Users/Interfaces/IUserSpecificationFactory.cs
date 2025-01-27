using Common.Domain.Specification;
using Domain.Modules.Users.Data;

namespace Domain.Modules.Users.Interfaces;

public interface IUserSpecificationFactory
{
    SpecificationBuilderDirector CreateForCreation(UserCreationData data);
}