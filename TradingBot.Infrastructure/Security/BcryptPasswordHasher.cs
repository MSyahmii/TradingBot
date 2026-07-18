using System;
using System.Collections.Generic;
using System.Text;
using BCrypt.Net;
using TradingBot.Application.Common.Interfaces;

namespace TradingBot.Infrastructure.Security;

public class BcryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
