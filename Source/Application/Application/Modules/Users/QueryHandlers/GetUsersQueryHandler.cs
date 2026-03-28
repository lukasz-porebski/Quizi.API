using Application.Contracts.Modules.Users.Dtos;
using Application.Contracts.Modules.Users.Interfaces;
using Application.Contracts.Modules.Users.Queries;
using LP.Common.Application.Contracts.ReadModel;
using LP.Common.Application.Contracts.User;
using LP.Common.Application.CQRS;

namespace Application.Modules.Users.QueryHandlers;

public class GetUsersQueryHandler(IUsersReadModel readModel, IUserContextProvider userContextProvider)
    : IQueryHandler<GetUsersQuery, PaginatedListDto<UsersListItemDto>>
{
    public Task<PaginatedListDto<UsersListItemDto>> Handle(GetUsersQuery query, CancellationToken cancellationToken) =>
        readModel.Get(query, userContextProvider.GetOrThrow().UserId, cancellationToken);
}