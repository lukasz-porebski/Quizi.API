using Common.Domain.ValueObjects;

namespace Domain.Modules.Roles.Data;

public record RoleCreationData(
    AggregateId Id,
    string Name,
    IReadOnlySet<AggregateId> PermissionIds
);