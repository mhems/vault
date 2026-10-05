namespace Vault.Application
{
    public interface ILootPoolApi
    {
        #region queries
        Task<List<LootPoolDto>> GetLootPoolsAsync(CancellationToken ct);

        Task<List<LootPoolDto>> GetLootPoolsByMembershipAsync(Guid id, CancellationToken ct);

        Task<LootPoolDto> GetLootPoolAsync(Guid id, CancellationToken ct);

        #endregion
    }
}
