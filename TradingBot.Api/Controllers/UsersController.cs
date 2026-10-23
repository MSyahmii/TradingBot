using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingBot.Application.Users.Login;
using TradingBot.Application.Users.Register;

namespace TradingBot.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UsersController : ControllerBase
{
    private readonly RegisterUserHandler _registerUserHandler;
    private readonly LoginUserHandler _loginUserHandler;

    public UsersController(RegisterUserHandler registerUserHandler, LoginUserHandler loginUserHandler)
    {
        _registerUserHandler = registerUserHandler;
        _loginUserHandler = loginUserHandler;
    }
          
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await _registerUserHandler.HandleAsync(request);

        return Created(string.Empty, result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequest request)
    {
        var result = await _loginUserHandler.HandleAsync(request);

        return Ok(result);
    }

    [HttpGet("Me")]
    [Authorize]
    public IActionResult Me()
    {
        var username = User.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
            
        return Ok(new { Username = username });
    }

}  

