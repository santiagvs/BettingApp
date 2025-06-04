using Microsoft.AspNetCore.Mvc;
using BettingApp.Domain.Models;
using BettingApp.Domain.Interfaces.Services;

namespace BettingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IAccountService accountService, ILogger<AccountController> logger) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        private readonly ILogger<AccountController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            if (account == null)
            {
                _logger.LogWarning($"Account with ID {id} not found.");
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(Account account)
        {
            await _accountService.CreateAsync(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
        }
    }
}
