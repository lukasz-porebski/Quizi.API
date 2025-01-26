using Common.Shared.Providers;
using Microsoft.Extensions.Localization;

namespace Common.Host.Providers;

public class MessageProvider(IStringLocalizerFactory stringLocalizerFactory) : IMessageProvider
{
    private readonly IStringLocalizer _localizer = stringLocalizerFactory.Create("Messages", nameof(BaseAssemblies.Host));

    public string GetMessage(string key) =>
        _localizer[key].Value;
}