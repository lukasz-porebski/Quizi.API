namespace Infrastructure.Endpoints.Modules.Users.Requests;

public record CreateUserRequest(
    string Email,
    string Password
);