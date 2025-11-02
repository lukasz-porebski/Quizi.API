using Common.Application.Contracts.User;
using Common.Application.Exceptions;
using Common.Domain.ValueObjects;
using Common.Host.Extensions;
using Common.Shared.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Common.Host.Providers;

[Provider]
public class UserContextProvider(IHttpContextAccessor httpContextAccessor, IHostEnvironment env) : IUserContextProvider
{
    public UserContextData? Get()
    {
        if (httpContextAccessor.HttpContext is null)
            return null;

        var isUser = httpContextAccessor.HttpContext.TryGetUserId(out var id);
        if (isUser)
            return new UserContextData(id);

        return env.IsDevelopment()
            ? new UserContextData(new AggregateId("c4b75a69-cf84-4840-9dde-2bdc073e4a02"))
            : null;
    }

    public UserContextData GetOrThrow() =>
        Get() ?? throw new BusinessLogicException("Failed to provide user context.");
}