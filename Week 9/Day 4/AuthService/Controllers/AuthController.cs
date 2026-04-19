using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService.Services.AuthService _service;

        public AuthController(AuthService.Services.AuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public IActionResult Register(User u)
        {
            return Ok(_service.Register(u));
        }

        [HttpPost("login")]
        public IActionResult Login(User u)
        {
            var token = _service.Login(u.Email, u.Password);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
    }
}