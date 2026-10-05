namespace Vault.Application
{
    public interface IShieldApi
    {
        Task<List<ShieldItemDto>> GetShieldsAsync(CancellationToken ct);

        Task<List<ShieldItemDto>> GetShieldsByPlayerAsync(Guid id, CancellationToken ct);

        Task<List<ShieldItemDto>> GetShieldsByModelAsync(Guid id, CancellationToken ct);

        Task<List<ShieldItemDto>> GetShieldsByRarityAsync(Guid id, CancellationToken ct);

        Task<List<ShieldItemDto>> GetShieldsByLootDropAsync(Guid id, CancellationToken ct);

        Task<List<ShieldItemDto>> GetShieldsByElementAsync(string element, CancellationToken ct);

        Task<List<ShieldItemDto>> GetShieldsByTypeAsync(string type, CancellationToken ct);

        Task<List<ShieldItemDto>> GetShieldsByManufacturerAsync(string manufacturer, CancellationToken ct);

        Task<ShieldItemDto> GetShieldAsync(Guid id, CancellationToken ct);
    }
}
