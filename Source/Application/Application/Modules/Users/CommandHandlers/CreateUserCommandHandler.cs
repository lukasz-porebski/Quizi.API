using Application.Contracts.Modules.Users.Commands;
using Application.Contracts.Modules.Users.Interfaces;
using Common.Application.CQRS;
using Common.Application.Extensions;
using Domain.Modules.Users.Interfaces;
using Domain.Modules.Users.Models;

namespace Application.Modules.Users.CommandHandlers;

public class CreateUserCommandHandler(
    IUserRepository userRepository,
    IUserSpecificationFactory specificationFactory,
    IPasswordHasher passwordHasher
) : ICommandHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        await ValidateUserEmail(command, cancellationToken);

        var user = new User(command.Data, specificationFactory, passwordHasher);
        await userRepository.PersistAsync(user, cancellationToken);
    }

    private Task ValidateUserEmail(CreateUserCommand command, CancellationToken cancellationToken) =>
        userRepository.NotExistsOrThrowAsync(
            e => e.Email == command.Data.Email,
            UserMessageCodes.UserWithGivenEmailAlreadyExists,
            cancellationToken);
}