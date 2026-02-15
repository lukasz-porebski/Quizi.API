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
    IPermissionRepository permissionRepository
)
{
    public async Task SeedAsync()
    {
        var existing = await context.Permissions
            .Select(p => p.Name)
            .ToHashSetAsync();

        var toAdd = Permissions.All
            .Where(p => !existing.Contains(p))
            .Select(p => factory.Create(new PermissionCreationData(AggregateId.Generate(), p)))
            .ToArray();

        if (toAdd.IsEmpty())
            return;

        await permissionRepository.PersistAsync(toAdd, CancellationToken.None);
        await permissionRepository.SaveAsync(CancellationToken.None);
    }
}