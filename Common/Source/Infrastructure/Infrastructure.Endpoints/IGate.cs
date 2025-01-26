using Common.Application.Contracts.CQRS;

namespace Common.Infrastructure.Endpoints;

public interface IGate
{
    public Task DispatchCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand;

    Task DispatchCommandAsync<TRequest, TCommand>(TRequest request, CancellationToken cancellationToken)
        where TCommand : ICommand;

    public Task<TResult> DispatchQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken)
        where TQuery : IQuery<TResult>;

    public Task<TResult> DispatchQueryAsync<TQuery, TDto, TResult>(TQuery query, CancellationToken cancellationToken)
        where TQuery : IQuery<TDto>;
}