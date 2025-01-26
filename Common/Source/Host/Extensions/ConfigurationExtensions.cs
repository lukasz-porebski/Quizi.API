using Common.Host.AppSettings;
using Microsoft.Extensions.Configuration;

namespace Common.Host.Extensions;

public static class ConfigurationExtensions
{
    public static TModel GetOptions<TModel>(this IConfiguration source, SettingsSection<TModel> settingsSection)
        where TModel : new()
    {
        var model = new TModel();
        source.GetSection(settingsSection.Name).Bind(model);

        return model;
    }
}