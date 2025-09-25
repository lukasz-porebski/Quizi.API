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
        IReadOnlyCollection<string>? searchColumns = null,
        IReadOnlyCollection<string>? sortColumns = null)
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
            var allowedSortColumns = sortColumns ?? typeof(T).GetProperties().Select(p => p.Name.ToLower()).ToArray();
            if (!allowedSortColumns.Contains(pagination.Sort.ColumnName.ToLower()))
                throw new ArgumentException($"{pagination.Sort.ColumnName} column is not allowed.");

            var orderBy = $"{pagination.Sort.ColumnName} {(pagination.Sort.IsAscending ? "ASC" : "DESC")}";
            builder.OrderBy(orderBy);
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

    protected async Task<T?> GetDetailsWithElements<T>(
        string sqlQuery,
        Func<SqlMapper.GridReader, T, Task> setDetails,
        CancellationToken cancellationToken,
        object? parameters = null)
        where T : notnull
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate(sqlQuery, parameters);

        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        await using var multi = await connection.QueryMultipleAsync(selector.RawSql, selector.Parameters);

        var details = await multi.ReadFirstOrDefaultAsync<T>();
        if (details is null)
            return default;

        await setDetails(multi, details);

        return details;
    }

    protected async Task<IReadOnlyCollection<T>> GetList<T>(
        string sqlQuery,
        CancellationToken cancellationToken,
        object? parameters = null)
        where T : notnull
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate(sqlQuery, parameters);

        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);

        var result = await connection.QueryAsync<T>(selector.RawSql, selector.Parameters);

        return result.ToArray();
    }
}