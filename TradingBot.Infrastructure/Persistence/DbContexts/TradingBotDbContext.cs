using System;
using Microsoft.EntityFrameworkCore;
using TradingBot.Domain.Entities;


namespace TradingBot.Infrastructure.Persistence.DbContexts;

public class TradingBotDbContext : DbContext
{
    public TradingBotDbContext(DbContextOptions<TradingBotDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RefreshToken>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(token => token.UserId)
            .IsRequired();

         modelBuilder.Entity<RefreshToken>()
            .HasIndex(token => token.TokenHash)
            .IsUnique();
    }
}
