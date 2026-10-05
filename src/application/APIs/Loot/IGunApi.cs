namespace Vault.Application
{
    public interface IGunApi
    {
        Task<List<GunItemDto>> GetGunsAsync(CancellationToken ct);

        Task<List<GunItemDto>> GetGunsByPlayerAsync(Guid id, CancellationToken ct);

        Task<List<GunItemDto>> GetGunsByModelAsync(Guid id, CancellationToken ct);

        Task<List<GunItemDto>> GetGunsByRarityAsync(Guid id, CancellationToken ct);

        Task<List<GunItemDto>> GetGunsByLootDropAsync(Guid id, CancellationToken ct);

        Task<List<GunItemDto>> GetGunsByElementAsync(string element, CancellationToken ct);

        Task<List<GunItemDto>> GetGunsByTypeAsync(string type, CancellationToken ct);

        Task<List<GunItemDto>> GetGunsByManufacturerAsync(string manufacturer, CancellationToken ct);

        Task<GunItemDto> GetGunAsync(Guid id, CancellationToken ct);
    }
}
