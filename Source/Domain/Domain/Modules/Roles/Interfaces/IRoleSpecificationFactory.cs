using Domain.Modules.Roles.Data;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Roles.Interfaces;

public interface IRoleSpecificationFactory
{
    SpecificationBuilderDirector CreateForCreation(RoleCreationData data);
}