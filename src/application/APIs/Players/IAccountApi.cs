namespace Vault.Application
{
    public interface IAccountApi
    {
        #region queries
        Task<List<AccountDto>> GetAccountsAsync(CancellationToken ct);

        Task<AccountDto> GetAccountAsync(Guid id, CancellationToken ct);

        #endregion

        #region commands
        Task<Guid> AddAccountAsync(AddAccountRequest account, CancellationToken ct);
        #endregion
    }
}
