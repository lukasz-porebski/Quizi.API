using Newtonsoft.Json;

namespace Common.Identity.Models;

public record AuthenticateResponse(
    string UserId,
    string AccessToken,
    [property: JsonIgnore] string RefreshToken,
    [property: JsonIgnore] DateTime RefreshTokenExpiredAt
);