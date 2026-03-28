using Application.Contracts.Modules.Users.Dtos;
using Application.Contracts.Modules.Users.Interfaces;
using Application.Contracts.Modules.Users.Queries;
using Dapper;
using LP.Common.Application.Contracts.ReadModel;
using LP.Common.Domain.ValueObjects;
using LP.Common.Infrastructure.ReadModels.Dapper;

namespace Infrastructure.ReadModels.Modules.Users;

public class UsersReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
    : BaseReadModel(connectionStringProvider), IUsersReadModel
{
    public Task<PaginatedListDto<UsersListItemDto>> Get(
        GetUsersQuery query, AggregateId userId, CancellationToken cancellationToken)
    {
        var parameters = new
        {
            UserId = userId.ToString()
        };

        const string sqlQuery = @$"
SELECT
    U.Id AS {nameof(UsersListItemDto.Id)},
    U.Email AS {nameof(UsersListItemDto.Email)},
    U.CreatedAt AS {nameof(UsersListItemDto.CreatedAt)}
FROM Users U
";

        return GetPaginatedList<UsersListItemDto>(
            query.Pagination,
            sqlQuery,
            orderByQuery: $"{nameof(UsersListItemDto.CreatedAt)} DESC",
            readItems: async reader => (await reader.ReadAsync<UsersListItemDto>()).ToArray(),
            cancellationToken,
            searchColumns: [nameof(UsersListItemDto.Email)],
            parameters: new DynamicParameters(parameters)
        );
    }
}