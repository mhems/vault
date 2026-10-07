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
            bool? unique,
            string? rarity,
            string? element,
            string? prefix,
            bool? missionItem,
            Manufacturer? barrel,
            Manufacturer? stock,
            Manufacturer? grip,
            Manufacturer? scope,
            Manufacturer? body,
            CancellationToken ct);

        Task<GunItemDto> GetGunAsync(Guid id, CancellationToken ct);
    }
}
