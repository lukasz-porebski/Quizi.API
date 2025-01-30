using Common.Identity.Interfaces;
using Common.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Identity;

[Route("identity")]
public class IdentityController(IIdentityService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await service.AuthenticateByCredentialsAsync(request, cancellationToken);
        SetTokenInCookies(response);
        return Ok(response);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string request, CancellationToken cancellationToken)
    {
        var response = await service.AuthenticateByRefreshTokenAsync(request, cancellationToken);
        SetTokenInCookies(response);
        return Ok(response);
    }

    private void SetTokenInCookies(AuthenticateResponse response)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = response.RefreshTokenExpiredAt
        };
        Response.Cookies.Append("refreshToken", response.RefreshToken, cookieOptions);
    }
}