using System.Data;
using BettingApp.Domain.Models;
using Dapper;

namespace BettingApp.Infrastructure.Repositories
{
    public class AccountRepository(IDbConnection connection)
    {
        private readonly IDbConnection _connection = connection;

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await _connection.QuerySingleOrDefaultAsync<Account>(
                "SELECT * FROM Accounts WHERE Id = @Id", new { Id = id });
        }

        public async Task CreateAsync(Account account)
        {
            await _connection.ExecuteAsync
            (
                @"INSERT INTO Accounts (Id, UserId, CardNumber, CardHolder, ExpirationDate, Balance)
                  VALUES (@Id, @UserId, @CardNumber, @CardHolder, @ExpirationDate, @Balance)",
                account
            );
        }
    }
}
