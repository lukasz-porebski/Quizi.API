using Application.Contracts.Modules.Roles.Interfaces;
using Domain.Modules.Roles.Data;
using Domain.Modules.Roles.Interfaces;
using Infrastructure.Database;
using LP.Common.Domain.ValueObjects;
using LP.Common.Host.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Host.Seeders;

[Seeder]
public class RoleSeeder(
    AppDbContext context,
    IRoleFactory factory,
    IRoleRepository repository
)
{
    public async Task SeedAsync()
    {
        var permissionIds = await context.Permissions
            .Select(p => p.Id)
            .ToHashSetAsync();

        await SeedAdminAsync(permissionIds);

        await repository.SaveAsync(CancellationToken.None);
    }

    private async Task SeedAdminAsync(IReadOnlySet<AggregateId> permissionIds)
    {
        const string name = "Admin";
        var admin = await repository.GetAsync(e => e.Name == name, CancellationToken.None);

        if (admin is null)
            admin = factory.Create(new RoleCreationData(
                AggregateId.Generate(),
                name,
                permissionIds.ToHashSet()
            ));
        else
            admin.UpdatePermissions(permissionIds);

        await repository.PersistAsync(admin, CancellationToken.None);
    }
}