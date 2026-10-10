using Vault.Domain;

namespace Vault.Application
{
    public interface IRelicApi
    {
        Task<List<RelicItemDto>> GetRelicsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            string? subcategory,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            CancellationToken ct);

        Task<RelicItemDto> GetRelicAsync(Guid id, CancellationToken ct);
    }
}
