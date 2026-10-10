using Vault.Domain;

namespace Vault.Application
{
    public interface IGunApi
    {
        Task<List<GunItemDto>> GetGunsAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            Gun? category,
            Manufacturer? manufacturer,
            Dlc? dlc,
            int? minLevel,
            int? maxLevel,
            bool? unique,
            string? rarity,
            string? element,
            double? minElementalEffectChance,
            string? prefix,
            bool? missionItem,
            double? minAccuracy,
            double? minFireRate,
            int? minMagazineSize,
            int? maxMagazineSize,
            Manufacturer? barrel,
            Manufacturer? stock,
            Manufacturer? grip,
            Manufacturer? scope,
            Manufacturer? body,
            CancellationToken ct);

        Task<GunItemDto> GetGunAsync(Guid id, CancellationToken ct);
    }
}
