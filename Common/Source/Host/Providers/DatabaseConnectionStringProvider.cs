using Common.Host.AppSettings;
using Common.Host.Extensions;
using Common.Infrastructure.ReadModels.Dapper;
using Common.Shared.Attributes;
using Microsoft.Extensions.Configuration;

namespace Common.Host.Providers;

[Provider]
public class DatabaseConnectionStringProvider(IConfiguration configuration) : IDatabaseConnectionStringProvider
{
    public string Get()
    {
        return configuration.GetOptions(BaseAppSettingsSections.Database).ConnectionString;
    }
}