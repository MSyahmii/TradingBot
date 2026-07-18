using Microsoft.AspNetCore.Mvc;
using TradingBot.Application.Users.Register;

namespace TradingBot.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UsersController : ControllerBase
{
    private readonly RegisterUserHandler _handler;

    public UsersController(RegisterUserHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await _handler.HandleAsync(request);

        return Created(string.Empty, result);
    }
}  

