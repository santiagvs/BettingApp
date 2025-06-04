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
    }
}
