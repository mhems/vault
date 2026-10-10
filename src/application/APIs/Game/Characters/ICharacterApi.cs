using Vault.Domain;

namespace Vault.Application
{
    public interface ICharacterApi
    {
        #region queries
        Task<List<NonPlayableCharacterDto>> GetCharactersAsync(
            Dlc? dlc,
            string? species,
            string? affiliation,
            Guid? spawnLocationId,
            CancellationToken ct);

        Task<NonPlayableCharacterDto> GetCharacterAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
