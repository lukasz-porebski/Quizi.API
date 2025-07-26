using AutoMapper;
using Common.Application.Contracts.CQRS;
using Common.Infrastructure.Endpoints;
using MediatR;

namespace Common.Host;

public class Gate(IMediator mediator, IMapper mapper) : IGate
{
    public Task DispatchCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : ICommand =>
        mediator.Send(command, cancellationToken);

    public Task DispatchCommandAsync<TRequest, TCommand>(TRequest request, CancellationToken cancellationToken)
        where TCommand : ICommand
    {
        var command = mapper.Map<TRequest, TCommand>(request);
        return mediator.Send(command, cancellationToken);
    }

    public Task<TResult> DispatchQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken)
        where TQuery : IQuery<TResult> =>
        mediator.Send(query, cancellationToken);

    public async Task<TResult> DispatchQueryAsync<TQuery, TDto, TResult>(TQuery query, CancellationToken cancellationToken)
        where TQuery : IQuery<TDto>
    {
        var dto = await mediator.Send(query, cancellationToken);
        return mapper.Map<TDto, TResult>(dto);
    }

    public Task<TResult> DispatchQueryAsync<TRequest, TQuery, TDto, TResult>(
        TRequest request,
        CancellationToken cancellationToken)
        where TQuery : IQuery<TDto>
    {
        var query = mapper.Map<TRequest, TQuery>(request);
        return DispatchQueryAsync<TQuery, TDto, TResult>(query, cancellationToken);
    }
}