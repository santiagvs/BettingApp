using BettingApp.Domain.Interfaces.Repositories;
using BettingApp.Domain.Interfaces.Services;
using BettingApp.Domain.Models;

namespace BettingApp.Application.Services
{
    public class AccountService(IAccountRepository accountRepository) : IAccountService
    {
        private readonly IAccountRepository _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Account account)
        {
            await _accountRepository.CreateAsync(account);
        }

        public Task<IEnumerable<Account>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
