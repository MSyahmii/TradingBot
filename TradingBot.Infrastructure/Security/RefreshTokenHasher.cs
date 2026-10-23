using System.Text;
using System.Security.Cryptography;
using TradingBot.Application.Common.Interfaces;

namespace TradingBot.Infrastructure.Security;

public class RefreshTokenHasher : IRefreshTokenHasher
{
    public string Hash(string refreshToken)
    {
        return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken)));
    }
}
