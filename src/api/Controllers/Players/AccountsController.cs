using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController(IAccountApi api, LinkGenerator links) : VaultController(links)
    {
        #region route names
        internal const string GetAccountsRoute = "GetAccounts";
        internal const string GetAccountRoute = "GetAccount";

        internal const string AddAccountRoute = "AddAccount";
        internal const string StashItemRoute = "StashItem";
        internal const string WithdrawItemRoute = "WithdrawItem";
        #endregion

        private readonly IAccountApi api = api;

        #region queries
        [HttpGet(Name = GetAccountsRoute)]
        [ProducesResponseType(typeof(List<AccountResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AccountResponse>>> GetAccounts(CancellationToken ct)
        {
            var accounts = await api.GetAccountsAsync(ct);
            var linkedAccounts = accounts.Select(ConvertAccount).ToList();
            return Ok(linkedAccounts);
        }

        [HttpGet("{id}", Name = GetAccountRoute)]
        [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountResponse>> GetAccount(Guid id, CancellationToken ct)
        {
            try
            {
                var account = await api.GetAccountAsync(id, ct);
                var linkedAccount = ConvertAccount(account);
                return Ok(linkedAccount);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region commands
        [HttpPost(Name = AddAccountRoute)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> AddAccount(AddAccountRequest account, CancellationToken ct)
        {
            try
            {
                var id = await api.AddAccountAsync(account, ct);
                return CreatedAtRoute(
                    GetAccountRoute,
                    new { id },
                    new { id });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion
    }
}