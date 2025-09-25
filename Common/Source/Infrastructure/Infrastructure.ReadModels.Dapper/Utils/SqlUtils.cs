namespace Common.Infrastructure.ReadModels.Dapper.Utils;

public static class SqlUtils
{
    public static string GetTimeSpan(string start, string end) =>
        $"CONVERT(TIME, DATEADD(SECOND, DATEDIFF(SECOND, {start}, {end}), 0))";
}