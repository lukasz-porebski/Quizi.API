using Common.Domain.ValueObjects;
using Domain.Contracts.Modules.Users.Enums;

namespace Domain.Modules.Users.Data;

public record UserCreationData(
    AggregateId Id,
    string Email,
    string Password,
    UserRole Role
);