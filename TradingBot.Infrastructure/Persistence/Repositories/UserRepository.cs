using System;
using TradingBot.Application.Common.Interfaces;
using TradingBot.Domain.Entities;
using TradingBot.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace TradingBot.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TradingBotDbContext _dbContext;

    public UserRepository(TradingBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}
