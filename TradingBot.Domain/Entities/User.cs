using System;
using System.Collections.Generic;
using System.Text;

namespace TradingBot.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty!;
    public decimal Balance { get; private set; }
    private User() { } // For Entity Framework
    public User(string username, string email)
    {
        if(string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is required.");
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        Balance = 0;
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");
        Balance += amount;
    }

}
