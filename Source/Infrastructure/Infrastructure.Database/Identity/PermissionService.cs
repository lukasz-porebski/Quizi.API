using Common.Domain.ValueObjects;
using Common.Identity.EF.Interfaces;
using Common.Shared.Attributes;

namespace Infrastructure.Database.Identity;

[Service]
public class PermissionService(AppDbContext context) : IPermissionService
{
    public Task<IReadOnlySet<string>> GetUserPermissions(AggregateId id)
    {
        //TODO: Dodać implementację
        return Task.FromResult<IReadOnlySet<string>>(new HashSet<string>());
    }
}