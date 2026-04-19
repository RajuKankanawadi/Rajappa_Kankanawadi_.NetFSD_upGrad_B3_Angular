using Microsoft.AspNetCore.Mvc;
using WebApplication14.Models;
using WebApplication14.Services;

namespace WebApplication14.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private static List<UserInfo> users = new List<UserInfo>();
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register(UserInfo user)
    {
        users.Add(user);
        return Ok(user);
    }

    [HttpPost("login")]
    public IActionResult Login(UserInfo user)
    {
        var u = users.FirstOrDefault(x => x.EmailId == user.EmailId && x.Password == user.Password);

        if (u == null)
            return Unauthorized("Invalid credentials");

        var token = _tokenService.GenerateToken(u);

        return Ok(new { token });
    }
}
