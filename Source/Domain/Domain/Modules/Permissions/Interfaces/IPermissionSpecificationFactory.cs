using Domain.Modules.Permissions.Data;
using LP.Common.Domain.Specification;

namespace Domain.Modules.Permissions.Interfaces;

public interface IPermissionSpecificationFactory
{
    SpecificationBuilderDirector CreateForCreation(PermissionCreationData data);
}