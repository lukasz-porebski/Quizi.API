using Host.Seeders;

namespace Host.StartupConfigs;

internal static class ApplicationBuilderConfig
{
    public static async Task UseSeeders(this IApplicationBuilder builder)
    {
        await using var scope = builder.ApplicationServices.CreateAsyncScope();

        var permissionSeeder = scope.ServiceProvider.GetRequiredService<PermissionSeeder>();
        await permissionSeeder.SeedAsync();

        var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
        await roleSeeder.SeedAsync();
    }
}