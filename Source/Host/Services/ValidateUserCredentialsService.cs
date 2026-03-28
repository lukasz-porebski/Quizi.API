using Application.Contracts.Modules.Users.Interfaces;
using Host.Constants;
using LP.Common.Application.Exceptions;
using LP.Common.Application.Extensions;
using LP.Common.Domain.ValueObjects;
using LP.Common.Identity.Interfaces;
using LP.Common.Shared.Attributes;
using LP.Common.Shared.Utils;

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