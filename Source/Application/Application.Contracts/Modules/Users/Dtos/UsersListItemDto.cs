namespace Application.Contracts.Modules.Users.Dtos;

public class UsersListItemDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required DateTime CreatedAt { get; set; }
}