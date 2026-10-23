using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.WebUtilities;
using TradingBot.Application.Common.Interfaces;


namespace TradingBot.Infrastructure.Security;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    public string GenerateToken()
    {
        var randomBytes = RandomNumberGenerator.GetBytes(32);
        var token = WebEncoders.Base64UrlEncode(randomBytes);
        return token;
    }
}
