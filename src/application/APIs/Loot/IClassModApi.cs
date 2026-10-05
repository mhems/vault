namespace Vault.Application
{
    public interface IClassModApi
    {
        Task<List<ClassModItemDto>> GetClassModsAsync(CancellationToken ct);

        Task<List<ClassModItemDto>> GetClassModsByPlayerAsync(Guid id, CancellationToken ct);

        Task<List<ClassModItemDto>> GetClassModsByModelAsync(Guid id, CancellationToken ct);

        Task<List<ClassModItemDto>> GetClassModsByRarityAsync(Guid id, CancellationToken ct);

        Task<List<ClassModItemDto>> GetClassModsByLootDropAsync(Guid id, CancellationToken ct);

        Task<List<ClassModItemDto>> GetClassModsByClassAsync(string @class, CancellationToken ct);

        Task<List<ClassModItemDto>> GetClassModsByManufacturerAsync(string manufacturer, CancellationToken ct);

        Task<ClassModItemDto> GetClassModAsync(Guid id, CancellationToken ct);
    }
}
