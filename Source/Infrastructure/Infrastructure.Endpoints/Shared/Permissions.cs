namespace Infrastructure.Endpoints.Shared;

public static class Permissions
{
    public const string UsersList = "Users:List";

    public static IReadOnlyCollection<string> All =>
    [
        UsersList
    ];
}