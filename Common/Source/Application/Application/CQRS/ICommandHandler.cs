using Common.Application.Contracts.CQRS;
using MediatR;

namespace Common.Application.CQRS;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand;