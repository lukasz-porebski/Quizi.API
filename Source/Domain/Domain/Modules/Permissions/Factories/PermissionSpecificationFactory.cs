using Common.Domain.Specification;
using Common.Shared.Attributes;
using Domain.Modules.Permissions.Data;
using Domain.Modules.Permissions.Interfaces;
using Domain.Modules.Permissions.Specifications;

namespace Domain.Modules.Permissions.Factories;

[Factory]
internal class PermissionSpecificationFactory : IPermissionSpecificationFactory
{
    public SpecificationBuilderDirector CreateForCreation(PermissionCreationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<PermissionCreationData>(data)
            .And(new PermissionNameSpecification())
            .Build();
}