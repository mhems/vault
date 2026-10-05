namespace Vault.Application
{
    public interface IEquipmentItemApi
    {
        Task<List<EquipmentItemDto>> GetEquipmentItemsAsync(CancellationToken ct);

        Task<List<EquipmentItemDto>> GetEquipmentItemsByPlayerAsync(Guid id, CancellationToken ct);

        Task<List<EquipmentItemDto>> GetEquipmentItemsByModelAsync(Guid id, CancellationToken ct);
        Task<List<EquipmentItemDto>> GetEquipmentItemsByRarityAsync(Guid id, CancellationToken ct);
        Task<List<EquipmentItemDto>> GetEquipmentItemsByLootDropAsync(Guid id, CancellationToken ct);

        Task<List<EquipmentItemDto>> GetEquipmentItemsByCategoryAsync(string category, CancellationToken ct);

        Task<List<EquipmentItemDto>> GetEquipmentItemsByManufacturerAsync(string manufacturer, CancellationToken ct);

        Task<EquipmentItemDto> GetEquipmentItemAsync(Guid id, CancellationToken ct);
    }
}
