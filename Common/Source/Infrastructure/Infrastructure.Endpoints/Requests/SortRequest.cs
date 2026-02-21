namespace Common.Infrastructure.Endpoints.Requests;

public record SortRequest(string ColumnName, bool IsAscending);