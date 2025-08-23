using System.Text;
using Common.Application.Contracts.ReadModel;
using Common.Shared.Extensions;

namespace Common.Infrastructure.ReadModels.Dapper;

internal class ReadModelSqlBuilder
{
    public const string SearchColumnName = "SearchColumn";

    private readonly StringBuilder _builder = new();

    public ReadModelSqlBuilder AddPaginatedQuery(
        PaginationData pagination, string selectQuery, IReadOnlyCollection<string>? searchColumns)
    {
        var offset = (pagination.PageNumber - 1) * pagination.PageSize;

        var search = string.Empty;
        if (!searchColumns.IsEmpty())
            search = searchColumns!.Count == 1
                ? $", {searchColumns.ElementAt(0)} AS {SearchColumnName}"
                : $", CONCAT_WS(' ', {string.Join(", ", searchColumns)}) AS {SearchColumnName}";

        _builder.Append(@$"
;WITH List AS ({selectQuery}), 
SearchList AS (SELECT * {search} FROM List)

SELECT *
INTO #FinalList
FROM SearchList
/**where**/

SELECT COUNT(*) FROM #FinalList;

SELECT * FROM #FinalList
/**orderby**/
OFFSET {offset} ROWS
FETCH NEXT {pagination.PageSize} ROWS ONLY;
");

        return this;
    }

    public ReadModelSqlBuilder AddQuery(string query)
    {
        _builder.AppendLine(query);
        return this;
    }

    public string Build()
    {
        var result = _builder.ToString();
        _builder.Clear();
        return result;
    }
}