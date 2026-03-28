using Domain.Modules.Permissions.Data;
using Domain.Modules.Permissions.Interfaces;
using LP.Common.Domain.Entities;

namespace Domain.Modules.Permissions.Models;

public class Permission : BaseAggregateRoot
{
    internal Permission(
        PermissionCreationData data,
        IPermissionSpecificationFactory specificationFactory)
        : base(data.Id)
    {
        specificationFactory.CreateForCreation(data).ValidateAndThrow();

        Name = data.Name;
    }

    private Permission() : base(null!)
    {
    }

    public string Name { get; private set; } = null!;
}