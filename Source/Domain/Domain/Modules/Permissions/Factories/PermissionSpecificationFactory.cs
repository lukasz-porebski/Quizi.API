using Domain.Modules.Permissions.Data;
using Domain.Modules.Permissions.Interfaces;
using Domain.Modules.Permissions.Specifications;
using LP.Common.Domain.Specification;
using LP.Common.Shared.Attributes;

namespace Domain.Modules.Permissions.Factories;

[Factory]
internal class PermissionSpecificationFactory : IPermissionSpecificationFactory
{
    public SpecificationBuilderDirector CreateForCreation(PermissionCreationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<PermissionCreationData>(data)
            .And(new PermissionNameSpecification())
            .Build();
}