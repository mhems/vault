using Microsoft.EntityFrameworkCore;
using Vault.Application;
using Vault.Domain;

namespace Vault.Infrastructure
{
    public sealed class AccountApi(AppDbContext db) : IAccountApi
    {
        private readonly AppDbContext db = db;

        #region queries
        public async Task<List<AccountDto>> GetAccountsAsync(CancellationToken ct)
        {
            return await db.Accounts
              .AsNoTracking()
              .Select(p => new AccountDto(
                  p.Id,
                  p.Name,
                  p.BadassRank,
                  p.Players.Select(p => p.Id).ToList(),
                  p.Stash.Select(e => e.Id).ToList()))
              .ToListAsync(ct);
        }

        public async Task<AccountDto> GetAccountAsync(Guid id, CancellationToken ct)
        {
            return await db.Accounts
              .AsNoTracking()
              .Where(r => r.Id == id)
              .Select(p => new AccountDto(
                  p.Id,
                  p.Name,
                  p.BadassRank,
                  p.Players.Select(p => p.Id).ToList(),
                  p.Stash.Select(e => e.Id).ToList()))
              .SingleOrDefaultAsync(ct)
              ?? throw new KeyNotFoundException($"no such account exists with ID {id}");
        }

        #endregion

        #region commands
        public async Task<Guid> AddAccountAsync(AddAccountDto account, CancellationToken ct)
        {
            var accountEntity = new Account(account.Name)
            {
                BadassRank = account.BadassRank
            };

            await db.Accounts.AddAsync(accountEntity, ct);
            await db.SaveChangesAsync(ct);

            return accountEntity.Id;
        }
        #endregion
    }
}
