namespace Infrastructure.Endpoints.Modules.Users.Responses;

public class UsersListItemResponse
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required DateTime CreatedAt { get; set; }
}