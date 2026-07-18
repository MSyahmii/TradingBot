using TradingBot.Application.Common.Interfaces;
using TradingBot.Application.Users.Register;
using TradingBot.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using TradingBot.Infrastructure.Persistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RegisterUserHandler>();
builder.Services.AddDbContext<TradingBotDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
