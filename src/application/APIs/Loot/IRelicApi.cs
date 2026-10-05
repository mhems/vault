namespace Vault.Application
{
    public interface IRelicApi
    {
        Task<List<RelicItemDto>> GetRelicsAsync(CancellationToken ct);

        Task<List<RelicItemDto>> GetRelicsByPlayerAsync(Guid id, CancellationToken ct);

        Task<List<RelicItemDto>> GetRelicsByModelAsync(Guid id, CancellationToken ct);

        Task<List<RelicItemDto>> GetRelicsByRarityAsync(Guid id, CancellationToken ct);

        Task<List<RelicItemDto>> GetRelicsByLootDropAsync(Guid id, CancellationToken ct);

        Task<List<RelicItemDto>> GetRelicsByTypeAsync(string type, CancellationToken ct);

        Task<List<RelicItemDto>> GetRelicsByManufacturerAsync(string manufacturer, CancellationToken ct);

        Task<RelicItemDto> GetRelicAsync(Guid id, CancellationToken ct);
    }
}
