namespace BettingApp.Domain.Models
{
    public class Bet
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BetDate { get; set; }
        public string? Event { get; set; }
        public decimal Odds { get; set; }
        public string? Status { get; set; }
    }
}
