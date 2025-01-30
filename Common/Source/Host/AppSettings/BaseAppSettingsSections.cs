using Common.Host.AppSettings.Sections;

namespace Common.Host.AppSettings;

public abstract class BaseAppSettingsSections
{
    public static SettingsSection<MainSettings> Main => new(nameof(Main));
    public static SettingsSection<DatabaseSettings> Database => new(nameof(Database));
    public static SettingsSection<SwaggerSettings> Swagger => new(nameof(Swagger));
    public static SettingsSection<IdentitySettings> Identity => new(nameof(Identity));
}