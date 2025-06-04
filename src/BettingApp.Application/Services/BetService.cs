using BettingApp.Domain.Interfaces.Repositories;
using BettingApp.Domain.Interfaces.Services;
using BettingApp.Domain.Models;

namespace BettingApp.Application.Services
{
    public class BetService(IBetRepository betRepository) : IBetService
    {
        private readonly IBetRepository _betRepository = betRepository ?? throw new ArgumentNullException(nameof(betRepository));

        public async Task<Bet?> GetByIdAsync(Guid id)
        {
            return await _betRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Bet bet)
        {
            await _betRepository.CreateAsync(bet);
        }

        public Task<IEnumerable<Bet>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Bet entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
