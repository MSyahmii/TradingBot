using System;
using System.Collections.Generic;
using System.Text;
using TradingBot.Application.Common.Interfaces;
using TradingBot.Domain.Entities;
using TradingBot.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace TradingBot.Infrastructure.Persistence.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly TradingBotDbContext _dbContext;

    public RefreshTokenRepository(TradingBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        _dbContext.RefreshTokens.Add(refreshToken);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<RefreshToken?> GetByTokenHashAsync(string tokenHash)
    {
        return await _dbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.TokenHash == tokenHash);
    }
    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        _dbContext.RefreshTokens.Update(refreshToken);
        await _dbContext.SaveChangesAsync();
    }

}
