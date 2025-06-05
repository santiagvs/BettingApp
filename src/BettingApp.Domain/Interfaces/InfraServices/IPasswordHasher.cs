namespace BettingApp.Domain.Interfaces.InfraServices
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}
