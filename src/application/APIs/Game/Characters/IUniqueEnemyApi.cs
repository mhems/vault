namespace Vault.Application
{
    public interface IUniqueEnemyApi
    {
        #region queries
        Task<List<UniqueEnemyDto>> GetUniqueEnemiesAsync(CancellationToken ct);

        Task<UniqueEnemyDto> GetUniqueEnemyAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
