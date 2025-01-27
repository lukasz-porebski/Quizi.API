using Common.Application.Contracts.CQRS;
using Domain.Modules.Users.Data;

namespace Application.Contracts.Modules.Users.Commands;

public record CreateUserCommand(UserCreationData Data) : ICommand;