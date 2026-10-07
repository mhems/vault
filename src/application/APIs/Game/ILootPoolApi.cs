namespace Vault.Application
{
    public interface ILootPoolApi
    {
        #region queries
        Task<List<LootPoolDto>> GetLootPoolsAsync(Guid? modelId, CancellationToken ct);
        Task<LootPoolDto> GetLootPoolAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
