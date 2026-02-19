using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Common.Shared.Extensions;
using Domain.Modules.Roles.Data;
using Domain.Modules.Roles.Interfaces;

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