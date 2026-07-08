namespace TradingBot.Api
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddScoped<RegisterUserHandler>();

    public class Program
    {
    }
}
