namespace Vault.Application
{
    public interface IEnemyApi
    {
        #region queries
        Task<List<EnemyDto>> GetEnemiesAsync(CancellationToken ct);

        Task<EnemyDto> GetEnemyAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
