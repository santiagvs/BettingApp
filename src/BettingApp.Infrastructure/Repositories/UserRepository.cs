using System.Data;
using BettingApp.Domain.Interfaces.Repositories;
using BettingApp.Domain.Models;
using Dapper;

namespace BettingApp.Infrastructure.Repositories
{
    public class UserRepository(IDbConnection connection) : IUserRepository
    {
        private readonly IDbConnection _connection = connection;

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _connection.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Id = @Id", new { Id = id });
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _connection.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE email = @email", new { Email = email });
        }

        public async Task CreateAsync(User user)
        {
            await _connection.ExecuteAsync(
                "INSERT INTO Users (Id, Name, Email, PasswordHash, CreatedAt) VALUES (@Id, @Name, @Email, @PasswordHash, @CreatedAt)",
                user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _connection.QueryAsync<User>("SELECT * FROM Users");
        }

        public async Task UpdateAsync(User user)
        {
            await _connection.ExecuteAsync(
                @"UPDATE Users SET Name = @Name, Email = @Email, PasswordHash = @PasswordHash WHERE Id = @Id",
                user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _connection.ExecuteAsync(
                "DELETE FROM Users WHERE Id = @Id", new { Id = id });
        }
    }
}
