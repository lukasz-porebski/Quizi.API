using Common.Application.Contracts.CQRS;
using MediatR;

namespace Common.Application.CQRS;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>;