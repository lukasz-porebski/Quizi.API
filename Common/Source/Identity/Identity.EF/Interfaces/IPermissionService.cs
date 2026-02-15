using Common.Domain.ValueObjects;

namespace Common.Identity.EF.Interfaces;

public interface IPermissionService
{
    Task<IReadOnlySet<string>> GetUserPermissionsAsync(AggregateId id, CancellationToken cancellationToken);
}