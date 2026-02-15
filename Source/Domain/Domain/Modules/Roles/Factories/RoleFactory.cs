using Common.Shared.Attributes;
using Domain.Modules.Roles.Data;
using Domain.Modules.Roles.Interfaces;
using Domain.Modules.Roles.Models;

namespace Domain.Modules.Roles.Factories;

[Factory]
public class RoleFactory(IRoleSpecificationFactory specificationFactory) : IRoleFactory
{
    public Role Create(RoleCreationData data) =>
        new(data, specificationFactory);
}