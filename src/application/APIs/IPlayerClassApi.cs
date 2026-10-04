namespace Vault.Application
{
    public interface IPlayerClassApi
    {
        #region queries
        Task<List<PlayerClassDto>> GetPlayerClassesAsync(CancellationToken ct);

        Task<PlayerClassDto> GetPlayerClassAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
