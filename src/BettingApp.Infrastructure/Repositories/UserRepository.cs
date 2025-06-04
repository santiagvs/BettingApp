using System.Data;
using BettingApp.Domain.Models;
using Dapper;

namespace BettingApp.Infrastructure.Repositories
{
    public class UserRepository(IDbConnection connection)
    {
        private readonly IDbConnection _connection = connection;

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _connection.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Id = @Id", new { Id = id });
        }

        public async Task CreateAsync(User user)
        {
            await _connection.ExecuteAsync(
                "INSERT INTO Users (Id, Name, Email, PasswordHash, CreatedAt) VALUES (@Id, @Name, @Email, @PasswordHash, @CreatedAt)",
                user);
        }
    }
}
