using Domain.Contracts.Modules.Users.Enums;

namespace PublishedLanguage.Modules.Users.Requests;

public record CreateUserRequest(
    string Email,
    string Password,
    UserRole Role
);