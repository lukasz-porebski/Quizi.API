using Common.Domain.ValueObjects;

namespace Common.Identity.Interfaces;

public interface IValidateUserCredentialsService
{
    Task<AggregateId> ValidateAndThrow(string email, string password, CancellationToken cancellationToken);
}