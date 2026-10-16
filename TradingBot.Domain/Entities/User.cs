using System;

namespace TradingBot.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty!;
    public decimal Balance { get; private set; }
    public string PasswordHash { get; private set; }
    private User() { } // For Entity Framework
    public  User(string username, string email, string passwordHash)
    {
        if(string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is required.");
        if(string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");
        if(string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash is required.");

        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        Balance = 0;
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");
        Balance += amount;
    }

}
