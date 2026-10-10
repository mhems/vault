using Vault.Domain;

namespace Vault.Application
{
    public interface IEnemyApi
    {
        #region queries
        Task<List<EnemyDto>> GetEnemiesAsync(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            bool? hasShield,
            string? weakToElement,
            string? resistsElement,
            string? immuneToElement,
            Guid? canDropModelId,
            CancellationToken ct);

        Task<EnemyDto> GetEnemyAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
