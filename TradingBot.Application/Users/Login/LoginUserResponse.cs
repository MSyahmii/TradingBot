using System;

namespace TradingBot.Application.Users.Login;

public class LoginUserResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
