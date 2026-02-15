using Application.Contracts.Modules.Users.Dtos;
using Application.Contracts.Modules.Users.Queries;
using Common.Application.Contracts.ReadModel;
using Common.Domain.ValueObjects;

namespace Application.Contracts.Modules.Users.Interfaces;

public interface IUsersReadModel
{
    Task<PaginatedListDto<UsersListItemDto>> Get(
        GetUsersQuery query, AggregateId userId, CancellationToken cancellationToken);
}