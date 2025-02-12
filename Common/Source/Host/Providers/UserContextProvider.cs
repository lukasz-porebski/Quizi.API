using System.IdentityModel.Tokens.Jwt;
using Common.Application.Contracts.User;
using Common.Application.Exceptions;
using Common.Domain.ValueObjects;
using Common.Shared.Attributes;
using Microsoft.AspNetCore.Http;

namespace Common.Host.Providers;

[Provider]
public class UserContextProvider(HttpContext httpContext) : IUserContextProvider
{
    public UserContextData? Get() =>
        TryGetUserId(httpContext, out var id) ? new UserContextData(id!) : null;

    public UserContextData GetOrThrow() =>
        Get() ?? throw new BusinessLogicException("Failed to provide user context.");

    private static bool TryGetUserId(HttpContext httpContext, out AggregateId? result)
    {
        var claims = httpContext.User.Claims.ToArray();

        var sub = claims.SingleOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Sub)) ??
                  claims.SingleOrDefault(c => c.Properties.Any(p => p.Value.Equals(JwtRegisteredClaimNames.Sub)));

        return AggregateId.TryParse(sub?.Value ?? string.Empty, out result);
    }
}