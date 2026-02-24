using Common.Identity.Interfaces;
using Common.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Hosting;

namespace Common.Identity;

[Route("identity")]
public class IdentityController(IIdentityService service, IHostEnvironment env) : ControllerBase
{
    private const string RefreshTokenCookieKey = "refreshToken";

    [HttpPost("login")]
    [EnableRateLimiting(IdentityConstants.RateLimiterPolicy)]
    public async Task<ActionResult<AuthenticateResponse>> Login(
        [FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await service.AuthenticateByCredentialsAsync(request, cancellationToken);
        SetTokenInCookies(response);
        return Ok(response);
    }

    [HttpPost("refresh-token")]
    [EnableRateLimiting(IdentityConstants.RateLimiterPolicy)]
    public async Task<ActionResult<AuthenticateResponse>> RefreshToken(CancellationToken cancellationToken)
    {
        if (!Request.Cookies.TryGetValue(RefreshTokenCookieKey, out var refreshToken))
            return Unauthorized();

        var response = await service.AuthenticateByRefreshTokenAsync(refreshToken, cancellationToken);
        SetTokenInCookies(response);
        return Ok(response);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete(RefreshTokenCookieKey);
        return Ok();
    }

    private void SetTokenInCookies(AuthenticateResponse response)
    {
        var isDevelopment = env.IsDevelopment();
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = Request.IsHttps || !isDevelopment,
            SameSite = isDevelopment ? SameSiteMode.Lax : SameSiteMode.None,
            Path = "/",
            Expires = response.RefreshTokenExpiredAt,
        };
        Response.Cookies.Append(RefreshTokenCookieKey, response.RefreshToken, cookieOptions);
    }
}