namespace Infrastructure.Endpoints.Shared;

public static class AppPermissions
{
    public const string UsersList = "Users:List";

    public static IReadOnlyCollection<string> All =>
    [
        UsersList
    ];
}