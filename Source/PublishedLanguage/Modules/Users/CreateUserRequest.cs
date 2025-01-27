using Domain.Contracts.Modules.Users.Enums;

namespace PublishedLanguage.Modules.Users;

public record CreateUserRequest(
    string Email,
    string Password,
    UserRole Role
);