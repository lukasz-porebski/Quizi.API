namespace Common.Infrastructure.ReadModels.Dapper;

public interface IDatabaseConnectionStringProvider
{
    public string Get();
}