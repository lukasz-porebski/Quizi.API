using Domain.Modules.Permissions.Data;
using Domain.Modules.Permissions.Interfaces;
using Domain.Modules.Permissions.Models;
using LP.Common.Shared.Attributes;

namespace Domain.Modules.Permissions.Factories;

[Factory]
public class PermissionFactory(IPermissionSpecificationFactory specificationFactory) : IPermissionFactory
{
    public Permission Create(PermissionCreationData data) =>
        new(data, specificationFactory);
}