using Common.Shared.Attributes;
using Common.Shared.Providers;

namespace Common.Host.Providers;

[Provider]
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now() =>
        DateTime.UtcNow;
}