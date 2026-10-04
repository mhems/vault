namespace Vault.Application
{
    public interface IRarityApi
    {
        #region queries
        Task<List<RarityDto>> GetRaritiesAsync(CancellationToken ct);

        Task<RarityDto> GetRarityAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
