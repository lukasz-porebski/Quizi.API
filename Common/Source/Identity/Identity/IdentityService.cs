using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Common.Domain.ValueObjects;
using Common.Identity.EF.Entities;
using Common.Identity.Interfaces;
using Common.Identity.Models;
using Common.Shared.Providers;
using Common.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Common.Identity;

public class IdentityService<TDbContext>(
    IIdentityConfiguration identityConfiguration,
    IDateTimeProvider dateTimeProvider,
    IValidateUserCredentialsService validateUserCredentialsService,
    TDbContext dbContext,
    IHasher hasher
) : IIdentityService
    where TDbContext : DbContext
{
    public async Task<AuthenticateResponse> AuthenticateByCredentialsAsync(LoginRequest request,
        CancellationToken cancellationToken)
    {
        var userId = await validateUserCredentialsService.ValidateAndThrow(request.Email, request.Password, cancellationToken);
        return await AuthenticateAsync(userId, cancellationToken);
    }

    public async Task<AuthenticateResponse> AuthenticateByRefreshTokenAsync(string token, CancellationToken cancellationToken)
    {
        var hashedRefreshToken = hasher.Hash(token, identityConfiguration.RefreshTokenSalt);
        var dbSet = dbContext.Set<RefreshToken>();
        var now = dateTimeProvider.Now();

        var refreshTokenEntity = await dbSet.FirstOrDefaultAsync(e =>
            e.HashedToken == hashedRefreshToken, cancellationToken: cancellationToken);
        if (refreshTokenEntity == null || refreshTokenEntity.ExpiredAt < now)
            throw new UnauthorizedAccessException();

        var expiredTokens = await dbSet.Where(e => e.ExpiredAt < now).ToArrayAsync(cancellationToken: cancellationToken);
        dbSet.RemoveRange(expiredTokens.Append(refreshTokenEntity));

        return await AuthenticateAsync(refreshTokenEntity.UserId, cancellationToken);
    }

    private async Task<AuthenticateResponse> AuthenticateAsync(AggregateId userId, CancellationToken cancellationToken)
    {
        var accessToken = GenerateAccessToken(userId);
        var refreshToken = GenerateRefreshToken();

        var refreshTokenEntity = CreateRefreshTokenEntity(userId, refreshToken);
        await dbContext.AddAsync(refreshTokenEntity, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new AuthenticateResponse(userId.ToString(), accessToken, refreshToken, refreshTokenEntity.ExpiredAt);
    }

    private string GenerateAccessToken(AggregateId userId)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identityConfiguration.AccessTokenSecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            issuer: identityConfiguration.Issuer,
            audience: identityConfiguration.Audience,
            claims:
            [
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString())
            ],
            expires: dateTimeProvider.Now().AddMinutes(identityConfiguration.AccessTokenExpirationMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private RefreshToken CreateRefreshTokenEntity(AggregateId userId, string refreshToken)
    {
        var hashedRefreshToken = hasher.Hash(refreshToken, identityConfiguration.RefreshTokenSalt);
        return new RefreshToken(
            AggregateId.Generate(),
            hashedRefreshToken,
            userId,
            dateTimeProvider.Now().AddDays(identityConfiguration.RefreshTokenExpirationDays)
        );
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}