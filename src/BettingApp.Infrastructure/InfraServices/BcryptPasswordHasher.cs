using BettingApp.Domain.Interfaces.InfraServices;

namespace BettingApp.Infrastructure.InfraServices
{
    public class BcryptPasswordHasher(int workFactor = 12) : IPasswordHasher
    {
        private readonly int _workFactor = workFactor;

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
