
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Auth;
using Shared.Models;

namespace Bakalarska_prace_Server.Controllers.AuthController

{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto userRegisterDto)
        {
            return Ok(new RegisterResponseDto { Error = RegisterError.None, Success = true });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto userLoginDto)
        {
            return Ok(new LoginResponseDto
            {
                Token = "123",
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                Username = userLoginDto.Login
            });
        }
    }
}