namespace Common.Identity.Interfaces;

public interface IIdentityConfiguration
{
    string Issuer { get; }
    string Audience { get; }
    string AccessTokenSecretKey { get; }
    int AccessTokenExpirationMinutes { get; }
    string RefreshTokenSalt { get; }
    int RefreshTokenExpirationDays { get; }
}