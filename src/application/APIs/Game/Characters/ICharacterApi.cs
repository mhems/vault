namespace Vault.Application
{
    public interface ICharacterApi
    {
        #region queries
        Task<List<NonPlayableCharacterDto>> GetCharactersAsync(CancellationToken ct);

        Task<NonPlayableCharacterDto> GetCharacterAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
