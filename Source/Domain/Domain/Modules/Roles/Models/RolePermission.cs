using Common.Domain.Entities;
using Common.Domain.ValueObjects;

namespace Domain.Modules.Roles.Models;

public class RolePermission : BaseEntityCore
{
    internal RolePermission(AggregateId id, AggregateId permissionId) : base(id)
    {
        PermissionId = permissionId;
    }

    private RolePermission()
    {
    }

    public AggregateId PermissionId { get; private set; } = null!;
}