using System.Data;
using BettingApp.Domain.Interfaces.Repositories;
using BettingApp.Domain.Models;
using Dapper;

namespace BettingApp.Infrastructure.Repositories
{
    public class BetRepository(IDbConnection connection) : IBetRepository
    {
        private readonly IDbConnection _connection = connection;

        public async Task<Bet?> GetByIdAsync(Guid id)
        {
            return await _connection.QuerySingleOrDefaultAsync<Bet>(
                "SELECT * FROM Bets WHERE Id = @Id", new { Id = id });
        }

        public async Task CreateAsync(Bet bet)
        {
            await _connection.ExecuteAsync
            (
                @"INSERT INTO Bets (Id, UserId, Amount, BetDate, Event, Odds, Status)
                VALUES (@Id, @UserId, @Amount, @BetDate, @Event, @Odds, @Status)",
                bet
            );
        }

        public async Task<IEnumerable<Bet>> GetAllAsync()
        {
            return await _connection.QueryAsync<Bet>("SELECT * FROM Bets");
        }

        public async Task UpdateAsync(Bet bet)
        {
            await _connection.ExecuteAsync(
                @"UPDATE Bets SET UserId = @UserId, Amount = @Amount, BetDate = @BetDate, Event = @Event, Odds = @Odds, Status = @Status
                WHERE Id = @Id",
                bet);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _connection.ExecuteAsync(
                "DELETE FROM Bets WHERE Id = @Id", new { Id = id });
        }
    }
}
