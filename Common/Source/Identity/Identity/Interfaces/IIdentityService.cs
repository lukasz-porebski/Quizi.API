using Common.Identity.Models;

namespace Common.Identity.Interfaces;

public interface IIdentityService
{
    Task<AuthenticateResponse> AuthenticateByCredentialsAsync(LoginRequest request, CancellationToken cancellationToken);
    Task<AuthenticateResponse> AuthenticateByRefreshTokenAsync(string token, CancellationToken cancellationToken);
}