using BettingApp.Domain.Models;

namespace BettingApp.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id);
        Task CreateAsync(Account account);
    }
}
