using Application.Contracts.Modules.Users.Dtos;
using Common.Application.Contracts.CQRS;
using Common.Application.Contracts.ReadModel;

namespace Application.Contracts.Modules.Users.Queries;

public record GetUsersQuery(PaginationData Pagination) : IQuery<PaginatedListDto<UsersListItemDto>>;