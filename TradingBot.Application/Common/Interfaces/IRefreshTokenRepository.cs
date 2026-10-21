using System;
using TradingBot.Domain.Entities;

namespace TradingBot.Application.Common.Interfaces;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken refreshToken);
    Task<RefreshToken?> GetByTokenHashAsync(string tokenHash);
    Task UpdateAsync(RefreshToken refreshToken);

}
