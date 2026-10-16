using System;

namespace TradingBot.Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string TokenHash { get; private set; } = string.Empty;
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime ExpiresAtUtc { get; private set; }
    public DateTime? RevokedAtUtc { get; private set; }

    private RefreshToken() { } // For Entity Framework

    public RefreshToken(Guid userId , string tokenHash, DateTime createdAtUtc, DateTime expiresAtUtc)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User ID is required.");
        if (string.IsNullOrWhiteSpace(tokenHash))
            throw new ArgumentException("Token hash is required.");
        if (createdAtUtc.Kind != DateTimeKind.Utc || expiresAtUtc.Kind != DateTimeKind.Utc)
            throw new ArgumentException("Dates must be in UTC.");
        if (expiresAtUtc <= createdAtUtc)
            throw new ArgumentException("Expiration date must be after creation date.");

        Id = Guid.NewGuid();
        UserId = userId;
        TokenHash = tokenHash;
        CreatedAtUtc = createdAtUtc;
        ExpiresAtUtc = expiresAtUtc;
    }
}
