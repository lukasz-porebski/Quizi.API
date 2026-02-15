using Common.Domain.ValueObjects;
using Common.Identity.EF.Interfaces;
using Common.Shared.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Identity;

[Service]
public class PermissionService(AppDbContext context) : IPermissionService
{
    public async Task<IReadOnlySet<string>> GetUserPermissions(AggregateId id) =>
        await (
                from ur in context.UserRoles
                join rp in context.RolePermissions on ur.RoleId equals rp.Id
                join p in context.Permissions on rp.PermissionId equals p.Id
                where ur.Id == id
                select p.Name
            )
            .Distinct()
            .ToHashSetAsync();
}