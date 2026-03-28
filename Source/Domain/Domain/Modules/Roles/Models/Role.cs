using Domain.Modules.Roles.Data;
using Domain.Modules.Roles.Interfaces;
using LP.Common.Domain.Entities;
using LP.Common.Domain.ValueObjects;
using LP.Common.Shared.Extensions;

namespace Domain.Modules.Roles.Models;

public class Role : BaseAggregateRoot
{
    private readonly List<RolePermission> _permissions = [];

    internal Role(
        RoleCreationData data,
        IRoleSpecificationFactory specificationFactory)
        : base(data.Id)
    {
        specificationFactory.CreateForCreation(data).ValidateAndThrow();

        Name = data.Name;

        _permissions = data.PermissionIds
            .Select(permissionId => new RolePermission(Id, permissionId))
            .ToList();
    }

    private Role() : base(null!)
    {
    }

    public string Name { get; private set; } = null!;

    public IReadOnlyList<RolePermission> Permissions => _permissions;

    public void UpdatePermissions(IReadOnlySet<AggregateId> ids) =>
        _permissions.ApplyChanges(
            ids,
            k => k.PermissionId,
            k => k,
            a => new RolePermission(Id, a),
            (_, _) => { },
            (_, _) => false
        );
}