using Application.Contracts.Modules.Users.Commands;
using Application.Contracts.Modules.Users.Interfaces;
using Common.Application.CQRS;
using Common.Application.Extensions;
using Domain.Modules.Users.Interfaces;

namespace Application.Modules.Users.CommandHandlers;

public class CreateUserCommandHandler(IUserRepository repository, IUserFactory factory) : ICommandHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        await ValidateUserEmail(command, cancellationToken);

        var user = factory.Create(command.Data);
        await repository.PersistAsync(user, cancellationToken);
    }

    private Task ValidateUserEmail(CreateUserCommand command, CancellationToken cancellationToken) =>
        repository.NotExistsOrThrowAsync(
            e => e.Email == command.Data.Email,
            UserMessageCodes.UserWithGivenEmailAlreadyExists,
            cancellationToken
        );
}