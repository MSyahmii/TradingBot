using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingBot.Application.Common.Interfaces;
using TradingBot.Domain.Entities;

namespace TradingBot.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }
        public Task<User?> GetByEmailAsync(string email)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            return Task.FromResult(user);
        }
        public Task<User?> GetByUsernameAsync(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            return Task.FromResult(user);
        }
    }
}
