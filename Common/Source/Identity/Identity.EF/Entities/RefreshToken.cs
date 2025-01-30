using Common.Domain.ValueObjects;

namespace Common.Identity.EF.Entities;

public class RefreshToken
{
    public RefreshToken(AggregateId id, string hashedToken, AggregateId userId, DateTime expiredAt)
    {
        Id = id;
        HashedToken = hashedToken;
        UserId = userId;
        ExpiredAt = expiredAt;
    }

    private RefreshToken()
    {
    }

    public AggregateId Id { get; private set; } = null!;
    public string HashedToken { get; private set; } = null!;
    public AggregateId UserId { get; private set; } = null!;
    public DateTime ExpiredAt { get; private set; }
}