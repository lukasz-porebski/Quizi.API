using System.Text.Json.Serialization;

namespace Common.Host.AppSettings.Sections;

public class LoggingSettings
{
    public LoggingLogLevelSettings LogLevel { get; set; } = new();
}

public class LoggingLogLevelSettings
{
    public string Default { get; set; } = "";

    [JsonPropertyName("Microsoft.AspNetCore")]
    public string MicrosoftAspNetCore { get; set; } = "";
}