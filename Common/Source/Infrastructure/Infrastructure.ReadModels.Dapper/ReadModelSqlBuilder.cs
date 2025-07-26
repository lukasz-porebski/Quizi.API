using System.Text;
using Common.Application.Contracts.ReadModel;

namespace Common.Infrastructure.ReadModels.Dapper;

internal class ReadModelSqlBuilder
{
    private readonly StringBuilder _builder = new();

    public ReadModelSqlBuilder AddPaginatedQuery(PaginationData pagination, string selectQuery)
    {
        var offset = (pagination.PageNumber - 1) * pagination.PageSize;

        _builder.Append(@$"
;WITH List AS ({selectQuery})

SELECT *
INTO #FinalList
FROM List
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