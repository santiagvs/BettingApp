using BettingApp.Domain.Models;

namespace BettingApp.Domain.Interfaces.Services
{
    public interface IUserService : IService<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
