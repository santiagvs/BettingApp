using BettingApp.Domain.DTO;
using BettingApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BettingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService ?? throw new ArgumentNullException(nameof(authService));

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var token = await _authService.LoginAsync(loginDTO.Email, loginDTO.Password);

            if (token == null) return Unauthorized(new { Message = "INVALID_CREDENTIALS" });

            return Ok(new { Token = token });
        }
    }
}
