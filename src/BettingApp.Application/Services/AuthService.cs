using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BettingApp.Domain.Interfaces.InfraServices;
using BettingApp.Domain.Interfaces.Services;
using BettingApp.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace BettingApp.Application.Services
{
    public class AuthService(IUserService userService, IPasswordHasher passwordHasher, IConfiguration configuration)
        : IAuthService
    {
        private readonly IUserService _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        private readonly IPasswordHasher _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        private readonly string _secretKey = configuration["JwtSettings:SecretKey"] ?? throw new ArgumentNullException("JwtSettings:SecretKey");

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null || !_passwordHasher.VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ?? string.Empty),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
