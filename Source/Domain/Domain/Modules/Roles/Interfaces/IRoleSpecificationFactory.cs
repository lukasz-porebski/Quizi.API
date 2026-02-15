using Common.Domain.Specification;
using Domain.Modules.Roles.Data;

namespace Domain.Modules.Roles.Interfaces;

public interface IRoleSpecificationFactory
{
    SpecificationBuilderDirector CreateForCreation(RoleCreationData data);
}