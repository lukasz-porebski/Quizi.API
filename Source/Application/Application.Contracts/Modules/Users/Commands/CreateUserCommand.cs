using Domain.Modules.Users.Data;
using LP.Common.Application.Contracts.CQRS;

namespace Application.Contracts.Modules.Users.Commands;

public record CreateUserCommand(UserCreationData Data) : ICommand;