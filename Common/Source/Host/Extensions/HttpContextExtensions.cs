using System.IdentityModel.Tokens.Jwt;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Common.Host.Extensions;

internal static class HttpContextExtensions
{
    public static bool TryGetUserId(this HttpContext source, out AggregateId result)
    {
        if (source.User.Identity?.IsAuthenticated == false)
        {
            result = AggregateId.Empty;
            return false;
        }

        var claims = source.User.Claims.ToArray();
        var sub = claims.SingleOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Sub)) ??
                  claims.SingleOrDefault(c => c.Properties.Any(p => p.Value.Equals(JwtRegisteredClaimNames.Sub)));

        return AggregateId.TryParse(sub?.Value ?? string.Empty, out result);
    }
}