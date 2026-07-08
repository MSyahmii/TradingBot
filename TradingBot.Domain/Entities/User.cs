using System;
using System.Collections.Generic;
using System.Text;

namespace TradingBot.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty!;
        public decimal Balance { get; private set; }
        private User() { }
        private User(string username, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Balance = 0;
        }

    }
}
