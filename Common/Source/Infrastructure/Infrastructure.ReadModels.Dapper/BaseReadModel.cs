using Common.Application.Contracts.ReadModel;
using Common.Shared.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Common.Infrastructure.ReadModels.Dapper;

public abstract class BaseReadModel(IDatabaseConnectionStringProvider connectionStringProvider)
{
    private readonly string _connectionString = connectionStringProvider.Get();

    protected async Task<PaginatedListDto<T>> GetPaginatedList<T>(
        PaginationData pagination,
        string paginatedQuery,
        string orderByQuery,
        Func<SqlMapper.GridReader, Task<IReadOnlyCollection<T>>> readItems,
        CancellationToken cancellationToken,
        string? elementsQuery = null,
        DynamicParameters? parameters = null,
        IReadOnlyCollection<string>? searchColumns = null)
        where T : notnull
    {
        var query = new ReadModelSqlBuilder()
            .AddPaginatedQuery(pagination, paginatedQuery, searchColumns)
            .AddQuery(elementsQuery ?? string.Empty)
            .Build();

        var builder = new SqlBuilder();
        var selector = builder.AddTemplate(query, parameters);

        if (!searchColumns.IsEmpty() && !pagination.Search.IsEmpty())
            builder.Where($"{ReadModelSqlBuilder.SearchColumnName} LIKE @SerachValue", new
            {
                SerachValue = $"%{pagination.Search}%"
            });

        if (pagination.Sort is not null)
        {
            var orderBy = $"@SortColumnName {(pagination.Sort.IsAscending ? "ASC" : "DESC")}";
            builder.OrderBy(orderBy, new { SortColumnName = pagination.Sort.ColumnName });
        }
        else
            builder.OrderBy(orderByQuery);


        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        await using var multi = await connection.QueryMultipleAsync(selector.RawSql, selector.Parameters);

        var totalCount = await multi.ReadSingleAsync<int>();
        var items = await readItems(multi);

        return new PaginatedListDto<T>(items, totalCount, pagination);
    }
}