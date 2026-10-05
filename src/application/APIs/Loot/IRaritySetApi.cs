namespace Vault.Application
{
    public interface IRaritySetApi
    {
        #region queries
        Task<List<RaritySetDto>> GetRaritySetsAsync(CancellationToken ct);

        Task<RaritySetDto> GetRaritySetAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
