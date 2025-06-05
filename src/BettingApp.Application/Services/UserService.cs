using BettingApp.Domain.Interfaces.InfraServices;
using BettingApp.Domain.Interfaces.Repositories;
using BettingApp.Domain.Interfaces.Services;
using BettingApp.Domain.Models;

namespace BettingApp.Application.Services
{
    public class UserService(IUserRepository userRepository, IPasswordHasher passwordHasher) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        private readonly IPasswordHasher _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task CreateAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (user.Id == null) user.Id = Guid.NewGuid();

            if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                    user.PasswordHash = _passwordHasher.HashPassword(user.PasswordHash);

            user.CreatedAt = DateTime.Now;

            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
