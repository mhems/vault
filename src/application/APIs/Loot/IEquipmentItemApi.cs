using Vault.Domain;

namespace Vault.Application
{
    public interface IEquipmentItemApi
    {
        Task<List<EquipmentItemDto>> GetEquipmentItemsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Equipment? category,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            CancellationToken ct);

        Task<EquipmentItemDto> GetEquipmentItemAsync(Guid id, CancellationToken ct);
    }
}
