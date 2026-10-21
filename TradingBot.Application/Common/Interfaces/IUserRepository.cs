using System;
using TradingBot.Domain.Entities;

namespace TradingBot.Application.Common.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);
}
