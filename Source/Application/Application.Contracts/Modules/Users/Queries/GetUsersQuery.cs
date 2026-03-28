using Application.Contracts.Modules.Users.Dtos;
using LP.Common.Application.Contracts.CQRS;
using LP.Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.Users.Queries;

public record GetUsersQuery(PaginationData Pagination) : IQuery<PaginatedListDto<UsersListItemDto>>;