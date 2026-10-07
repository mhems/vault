using Vault.Domain;

namespace Vault.Application
{
    public interface IGrenadeApi
    {
        Task<List<GrenadeItemDto>> GetGrenadesAsync(
            Guid? playerId,
            Guid? modelId,
            string? name,
            GrenadeDelivery? delivery,
            Manufacturer? manufacturer,
            Dlc? dlc,
            bool? unique,
            string? rarity,
            string? element,
            bool? sticky,
            CancellationToken ct);

        Task<GrenadeItemDto> GetGrenadeAsync(Guid id, CancellationToken ct);
    }
}
