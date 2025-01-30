using Application.Contracts.Modules.Users.Interfaces;
using Common.Application.Exceptions;
using Common.Application.Extensions;
using Common.Domain.ValueObjects;
using Common.Identity.Interfaces;
using Common.Shared.Attributes;
using Common.Shared.Utils;
using Host.Constants;

namespace Host.Services;

[Service]
public class ValidateUserCredentialsService(IUserRepository userRepository, IHasher hasher) : IValidateUserCredentialsService
{
    public async Task<AggregateId> ValidateAndThrow(string email, string password, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOrThrowAsync(
            e => e.Email == email, MessageCodes.InvalidUserEmailOrPassword, cancellationToken);

        if (!hasher.Verify(user.HashedPassword, password))
            throw new BusinessLogicException(MessageCodes.InvalidUserEmailOrPassword);

        return user.Id;
    }
}