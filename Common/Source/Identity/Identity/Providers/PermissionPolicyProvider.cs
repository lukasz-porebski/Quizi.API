using Common.Identity.Contracts.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Common.Identity.Providers;

public class PermissionPolicyProvider(IOptions<AuthorizationOptions> options) : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _defaultProvider = new(options);

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
        _defaultProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
        _defaultProvider.GetFallbackPolicyAsync();

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var permissions = PermissionAttribute.DecodePermissions(policyName);

        var policy = new AuthorizationPolicyBuilder()
            .RequireAssertion(ctx => permissions.Any(p => ctx.User.HasClaim(IdentityConstants.PermissionClaimType, p)))
            .Build();

        return Task.FromResult<AuthorizationPolicy?>(policy);
    }
}