using Common.Domain.Specification;
using Domain.Modules.Permissions.Data;

namespace Domain.Modules.Permissions.Interfaces;

public interface IPermissionSpecificationFactory
{
    SpecificationBuilderDirector CreateForCreation(PermissionCreationData data);
}