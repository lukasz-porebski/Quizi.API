using Domain.Modules.Roles.Data;
using Domain.Modules.Roles.Interfaces;
using Domain.Modules.Roles.Specifications;
using LP.Common.Domain.Specification;
using LP.Common.Shared.Attributes;

namespace Domain.Modules.Roles.Factories;

[Factory]
internal class RoleSpecificationFactory : IRoleSpecificationFactory
{
    public SpecificationBuilderDirector CreateForCreation(RoleCreationData data) =>
        new SpecificationBuilderDirector.SpecificationBuilder<RoleCreationData>(data)
            .And(new RoleNameSpecification())
            .Build();
}