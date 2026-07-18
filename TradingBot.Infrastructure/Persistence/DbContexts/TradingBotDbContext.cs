using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TradingBot.Domain.Entities;


namespace TradingBot.Infrastructure.Persistence.DbContexts;

public class TradingBotDbContext : DbContext
{
    public TradingBotDbContext(DbContextOptions<TradingBotDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}
