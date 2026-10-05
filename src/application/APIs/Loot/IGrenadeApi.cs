namespace Vault.Application
{
    public interface IGrenadeApi
    {
        Task<List<GrenadeItemDto>> GetGrenadesAsync(CancellationToken ct);

        Task<List<GrenadeItemDto>> GetGrenadesByPlayerAsync(Guid id, CancellationToken ct);

        Task<List<GrenadeItemDto>> GetGrenadesByModelAsync(Guid id, CancellationToken ct);

        Task<List<GrenadeItemDto>> GetGrenadesByRarityAsync(Guid id, CancellationToken ct);

        Task<List<GrenadeItemDto>> GetGrenadesByLootDropAsync(Guid id, CancellationToken ct);

        Task<List<GrenadeItemDto>> GetGrenadesByElementAsync(string element, CancellationToken ct);

        Task<List<GrenadeItemDto>> GetGrenadesByDeliveryAsync(string type, CancellationToken ct);

        Task<List<GrenadeItemDto>> GetGrenadesByManufacturerAsync(string manufacturer, CancellationToken ct);

        Task<GrenadeItemDto> GetGrenadeAsync(Guid id, CancellationToken ct);
    }
}
