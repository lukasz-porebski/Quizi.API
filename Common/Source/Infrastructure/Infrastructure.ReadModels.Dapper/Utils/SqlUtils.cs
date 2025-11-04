namespace Common.Infrastructure.ReadModels.Dapper.Utils;

public static class SqlUtils
{
    public static string GetTimeSpan(string start, string end) =>
        $"({end}::timestamp - {start}::timestamp)";
}