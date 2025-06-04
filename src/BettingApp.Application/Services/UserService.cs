using BettingApp.Domain.Interfaces.Repositories;
using BettingApp.Domain.Interfaces.Services;
using BettingApp.Domain.Models;

namespace BettingApp.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            // Implementação futura: retornar todos os usuários
            throw new NotImplementedException();
        }

        public async Task CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            // Implementação futura: atualizar dados do usuário
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            // Implementação futura: deletar usuário
            throw new NotImplementedException();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            // Implementação futura: buscar usuário pelo email
            throw new NotImplementedException();
        }
    }
}
