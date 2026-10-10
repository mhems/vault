using Vault.Domain;

namespace Vault.Application
{
    public interface IUniqueEnemyApi
    {
        #region queries
        Task<List<UniqueEnemyDto>> GetUniqueEnemiesAsync(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            bool? hasShield,
            string? weakToElement,
            string? resistsElement,
            string? immuneToElement,
            Guid? canDropModelId,
            bool? boss,
            bool? raidBoss,
            CancellationToken ct);

        Task<UniqueEnemyDto> GetUniqueEnemyAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
