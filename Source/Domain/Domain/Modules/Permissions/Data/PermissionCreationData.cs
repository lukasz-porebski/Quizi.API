using Common.Domain.ValueObjects;

namespace Domain.Modules.Permissions.Data;

public record PermissionCreationData(
    AggregateId Id,
    string Name
);