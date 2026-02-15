using Common.Domain.ValueObjects;

namespace Domain.Modules.Users.Data;

public record UserCreationData(
    AggregateId Id,
    string Email,
    string Password,
    IReadOnlySet<AggregateId> RoleIds
);