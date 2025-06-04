using Microsoft.AspNetCore.Mvc;
using BettingApp.Domain.Models;
using BettingApp.Domain.Interfaces.Services;

namespace BettingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetController(IBetService betService, ILogger<BetController> logger) : ControllerBase
    {
        private readonly IBetService _betService = betService ?? throw new ArgumentNullException(nameof(betService));
        private readonly ILogger<BetController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBetById(Guid id)
        {
            var bet = await _betService.GetByIdAsync(id);
            if (bet == null)
            {
                _logger.LogWarning($"Bet with ID {id} not found.");
                return NotFound();
            }

            return Ok(bet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBet(Bet bet)
        {
            await _betService.CreateAsync(bet);
            return CreatedAtAction(nameof(GetBetById), new { id = bet.Id }, bet);
        }
    }
}
