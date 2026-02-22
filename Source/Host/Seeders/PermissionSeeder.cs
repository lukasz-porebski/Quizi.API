using Application.Contracts.Modules.Permissions.Interfaces;
using Common.Domain.ValueObjects;
using Common.Host.Attributes;
using Common.Shared.Extensions;
using Domain.Modules.Permissions.Data;
using Domain.Modules.Permissions.Interfaces;
using Infrastructure.Database;
using Infrastructure.Endpoints.Shared;
using Microsoft.EntityFrameworkCore;

namespace Host.Seeders;

[Seeder]
public class PermissionSeeder(
    AppDbContext context,
    IPermissionFactory factory,
    IPermissionRepository repository
)
{
    public async Task SeedAsync() //TODO: Przerobić Startup by był asynchroniczny
    {
        var existing = await context.Permissions
            .Select(p => p.Name)
            .ToHashSetAsync();

        var toAdd = AppPermissions.All
            .Where(p => !existing.Contains(p))
            .Select(p => factory.Create(new PermissionCreationData(AggregateId.Generate(), p)))
            .ToArray();

        if (toAdd.IsEmpty())
            return;

        await repository.PersistAsync(toAdd, CancellationToken.None);
        await repository.SaveAsync(CancellationToken.None);
    }
}