namespace Common.Host.AppSettings.Sections;

public class RateLimiterSettings
{
    public int PermitLimit { get; set; }
    public int WindowMinutes { get; set; }
    public int QueueLimit { get; set; }
}