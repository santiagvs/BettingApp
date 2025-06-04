using BettingApp.Domain.Models;

namespace BettingApp.Domain.Interfaces.Repositories
{
    public interface IBetRepository
    {
        Task<Bet?> GetByIdAsync(Guid id);
        Task CreateAsync(Bet bet);
    }
}
