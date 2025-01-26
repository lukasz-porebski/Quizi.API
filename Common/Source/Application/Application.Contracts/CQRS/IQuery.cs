using MediatR;

namespace Common.Application.Contracts.CQRS;

public interface IQuery<TResult> : IRequest<TResult>;