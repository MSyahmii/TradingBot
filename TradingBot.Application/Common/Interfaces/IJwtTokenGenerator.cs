using System;
using System.Collections.Generic;
using System.Text;
using TradingBot.Domain.Entities;

namespace TradingBot.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
