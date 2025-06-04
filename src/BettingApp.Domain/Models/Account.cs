namespace BettingApp.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? CardNumber { get; set; }
        public string? CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Balance { get; set; }
    }
}
